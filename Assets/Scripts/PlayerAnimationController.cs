using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    #region Variables

    [SerializeField] private List<Animator> Animators;

    [SerializeField] private List<GameObject> Outfits, Hairs, Hats;

    public static Action<ItemType, int> OnItemEquipped;

    #endregion

    #region Methods

    /// <summary>
    /// Updates all active animators following the parameters
    /// </summary>
    /// <param name="dir">Player's looking direction: 0 - Front; 1 - Back; 2 - Right; 3 - Left;</param>
    /// <param name="isMoving"></param>
    public void UpdateAnimators(int dir, bool isMoving)
    {
        foreach (Animator animator in Animators)
        {
            if (animator.isActiveAndEnabled)
            {
                animator.SetInteger("Dir", dir);
                animator.SetBool("IsMoving", isMoving);
            }
        }
    }

    /// <summary>
    /// Equip the item provided by the parameters and UnEquip the others of the same category.
    /// </summary>
    /// <param name="type">Item Type</param>
    /// <param name="id">Item Id</param>
    public void EquipItem(ItemType type, int id)
    {
        switch (type)
        {
            case ItemType.Outfit:
                for (int i = 0; i < Outfits.Count; i++)
                {
                    if (i == id) Outfits[i].SetActive(true);
                    else Outfits[i].SetActive(false);
                }

                break;
            case ItemType.Hair:
                for (int i = 0; i < Hairs.Count; i++)
                {
                    if (i == id) Hairs[i].SetActive(true);
                    else Hairs[i].SetActive(false);
                }

                break;
            case ItemType.Hat:
                for (int i = 0; i < Hats.Count; i++)
                {
                    if (i == id) Hats[i].SetActive(true);
                    else Hats[i].SetActive(false);
                }

                break;
        }

        OnItemEquipped?.Invoke(type, id);
    }

    /// <summary>
    /// UnEquip all items of the same category.
    /// </summary>
    /// <param name="type"></param>
    public void UnEquipItem(ItemType type)
    {
        switch (type)
        {
            case ItemType.Outfit:
                for (int i = 0; i < Outfits.Count; i++)
                {
                    Outfits[i].SetActive(false);
                }

                break;
            case ItemType.Hair:
                for (int i = 0; i < Hairs.Count; i++)
                {
                    Hairs[i].SetActive(false);
                }

                break;
            case ItemType.Hat:
                for (int i = 0; i < Hats.Count; i++)
                {
                    Hats[i].SetActive(false);
                }

                break;
        }
    }

    #endregion
}

public enum ItemType
{
    Outfit,
    Hair,
    Hat
}