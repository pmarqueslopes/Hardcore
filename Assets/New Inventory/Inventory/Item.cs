using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public int itemID;
    public string itemDesc;
    public Sprite itemIcon;
    public GameObject itemModel;
    public int itemPower;
    public int itemSpeed;
    public int itemValue;
    public ItemType itemType;
    public int GemType;
    public int GemTier;

    public enum ItemType
    {
        None,
        Gem,
        Consumable,
        Potion,
        Head,
        Boots,
        Chest
    }

    public Item(string name,int id, string desc, int power, int speed, int value, ItemType type, int gemType, int gemTier)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemPower = power;
        itemSpeed = speed;
        itemValue = value;
        itemType = type;
        GemType = gemType;
        GemTier = gemTier;
        itemIcon = Resources.Load<Sprite>("" + name);
        itemModel = Resources.Load<GameObject>(name);
    }

    public Item()
    {
        
    }

}
