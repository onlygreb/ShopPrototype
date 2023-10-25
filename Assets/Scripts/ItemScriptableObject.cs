using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class ItemScriptableObject : ScriptableObject
{
    public Sprite itemIcon;
    public int itemPrice, itemId;
    public ItemType type;
}
