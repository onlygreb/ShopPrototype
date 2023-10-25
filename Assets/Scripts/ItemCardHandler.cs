using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCardHandler : MonoBehaviour
{
    #region Variables

    [SerializeField] private ItemScriptableObject item;
    [SerializeField] private Image itemIconImage;
    [SerializeField] private TMP_Text itemPriceText;

    [SerializeField] private Button buyItemBt, equipItemBt, equippedItemBt, sellItemBt;

    private bool _hasBoughtThisItem;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        itemIconImage.sprite = item.itemIcon;
        itemPriceText.text = item.itemPrice.ToString();

        _hasBoughtThisItem = false;

        PlayerAnimationController.OnItemEquipped += UpdateEquipAndEquippedButtons;
    }

    private void Update()
    {
        buyItemBt.interactable = UIShopManager.Instance.coinsQt >= item.itemPrice;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Equip the current Item by calling the EquipItem function from PlayerAnimationController.
    /// </summary>
    public void EquipItem()
    {
        if (!_hasBoughtThisItem) return;

        PlayerController.Instance.GetComponent<PlayerAnimationController>().EquipItem(item.type, item.itemId);
    }

    /// <summary>
    /// Buy the current Item.
    /// </summary>
    public void BuyItem()
    {
        // Verifying if the player hasn't the current item and if there is enough coins to buy it
        if (_hasBoughtThisItem) return;
        if (UIShopManager.Instance.coinsQt < item.itemPrice) return;

        _hasBoughtThisItem = true;

        UIShopManager.Instance.coinsQt -= item.itemPrice;

        buyItemBt.gameObject.SetActive(false);
        equipItemBt.gameObject.SetActive(true);
        sellItemBt.gameObject.SetActive(true);
    }

    /// <summary>
    /// Sells the current Item.
    /// </summary>
    public void SellItem()
    {
        if (!_hasBoughtThisItem) return;

        UIShopManager.Instance.coinsQt += item.itemPrice;
        _hasBoughtThisItem = false;

        if (equippedItemBt.gameObject.activeSelf)
            PlayerController.Instance.GetComponent<PlayerAnimationController>().UnEquipItem(item.type);

        buyItemBt.gameObject.SetActive(true);
        equipItemBt.gameObject.SetActive(false);
        equippedItemBt.gameObject.SetActive(false);
        sellItemBt.gameObject.SetActive(false);
    }

    /// <summary>
    /// Show Equip and Equipped buttons as needed.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="id"></param>
    private void UpdateEquipAndEquippedButtons(ItemType type, int id)
    {
        if (!_hasBoughtThisItem) return;
        if (type != item.type) return;

        if (id == item.itemId)
        {
            equipItemBt.gameObject.SetActive(false);
            equippedItemBt.gameObject.SetActive(true);
        }
        else
        {
            equipItemBt.gameObject.SetActive(true);
            equippedItemBt.gameObject.SetActive(false);
        }
    }

    #endregion
}