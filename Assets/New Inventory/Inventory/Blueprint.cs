using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Blueprint
{

    public List<int> ingridients = new List<int>();
    public Item finalItem;

    public Blueprint(List<int> ingridients, Item item)
    {
        this.ingridients = ingridients;
        finalItem = item;
    }
}
