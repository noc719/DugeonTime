using System;
using UnityEngine;

public enum ItemType
{
    Cusumable,
    Equipable
}

[CreateAssetMenu(fileName ="ItemObject",menuName ="ItemData",order = 0)]
public class ItemData: ScriptableObject
{
    [Header("ItemInfo")]
    public string itemName;
    public string discription;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stack")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Cunsumable")]
    public int value;
}