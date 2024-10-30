using System;
using UnityEngine;


[CreateAssetMenu(fileName ="ItemSlot",menuName ="ItemData",order = 0)]
public class ItemData: ScriptableObject
{
    [Header("ItemInfo")]
    public string itemName;
    public string discription;

    [Header("Cunsumable")]
    public int value;
}