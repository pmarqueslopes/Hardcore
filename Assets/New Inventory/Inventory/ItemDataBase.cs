using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
   
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        items.Add(new Item("Blue Gem", 0, "To blue you!", 10,10,1,Item.ItemType.Gem,1,1));
        items.Add(new Item("Green Gem", 6, "To green you!", 10,10,1,Item.ItemType.Gem,2,1));
        items.Add(new Item("Red Gem", 3, "To red you!", 10,10,1,Item.ItemType.Gem,3,1));
        items.Add(new Item("Health Potion", 9, "To Heal you", 10, 10, 1, Item.ItemType.Potion, 0, 0));

        items.Add(new Item("Blue Gem II", 1, "To blue you!", 10, 10, 3, Item.ItemType.Gem, 1, 2));
        items.Add(new Item("Green Gem II", 7, "To green you!", 10, 10, 3, Item.ItemType.Gem, 2, 2));
        items.Add(new Item("Red Gem II", 4, "To red you!", 10, 10, 3, Item.ItemType.Gem, 3, 2));

        items.Add(new Item("Blue Gem III", 2, "To blue you!", 10, 10, 3, Item.ItemType.Gem, 1, 3));
        items.Add(new Item("Green Gem III", 8, "To green you!", 10, 10, 3, Item.ItemType.Gem, 2, 3));
        items.Add(new Item("Red Gem III", 5, "To red you!", 10, 10, 3, Item.ItemType.Gem, 3, 3));
        items.Add(new Item("Fury Potion", 10, "To Enrage you", 10, 10, 1, Item.ItemType.Potion, 0, 0));

    }
}
