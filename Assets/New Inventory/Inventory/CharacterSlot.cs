using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterSlot : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public int index;

    public Item item;

    Inventory inventory;

    public bool armor;

    public int indexI;
    
    ItemDataBase dataBase;
    
    void LoadGems()
    {
        if (armor)
        {
            if (PlayerStats.instance.armorGems[indexI] == 1)
            {
                switch (PlayerStats.instance.armorGemsTier[indexI])
                {
                    case 1: item = dataBase.items[0];
                        break;
                    case 2:item = dataBase.items[1];
                        break;
                    case 3:item = dataBase.items[2];
                        break;
                }
            }
            if (PlayerStats.instance.armorGems[indexI] == 3)
            {
                switch (PlayerStats.instance.armorGems[indexI])
                {
                    case 1: item = dataBase.items[3];
                        break;
                    case 2:item = dataBase.items[4];
                        break;
                    case 3:item = dataBase.items[5];
                        break;
                }
            }
            if (PlayerStats.instance.armorGems[indexI] == 2)
            {
                switch (PlayerStats.instance.armorGems[indexI])
                {
                    case 1: item = dataBase.items[6];
                        break;
                    case 2:item = dataBase.items[7];
                        break;
                    case 3:item = dataBase.items[8];
                        break;
                }
            }
            
        }
        else
        {
            if (PlayerStats.instance.pickaxeGems[indexI] == 1)
            {
                switch (PlayerStats.instance.pickaxeGemsTier[indexI])
                {
                    case 1: item = dataBase.items[0];
                        break;
                    case 2:item = dataBase.items[1];
                        break;
                    case 3:item = dataBase.items[2];
                        break;
                }
            }
            if (PlayerStats.instance.pickaxeGems[indexI] == 3)
            {
                switch (PlayerStats.instance.pickaxeGemsTier[indexI])
                {
                    case 1: item = dataBase.items[3];
                        break;
                    case 2:item = dataBase.items[4];
                        break;
                    case 3:item = dataBase.items[5];
                        break;
                }
            }
            if (PlayerStats.instance.pickaxeGems[indexI] == 2)
            {
                switch (PlayerStats.instance.pickaxeGemsTier[indexI])
                {
                    case 1: item = dataBase.items[6];
                        break;
                    case 2:item = dataBase.items[7];
                        break;
                    case 3:item = dataBase.items[8];
                        break;
                }
            }
        }
    }
    
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        dataBase = GameObject.FindGameObjectWithTag("ItemDataBase").GetComponent<ItemDataBase>();
        LoadGems();
    }

    void Update()
    {
        if (item.itemType != Item.ItemType.None)
        {
            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().sprite = item.itemIcon;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }


    public void OnPointerDown(PointerEventData data)
    {
        if (inventory.draggingItem)
        {
            if (index == 0 && inventory.draggedItem.itemType == Item.ItemType.Gem)
            {
                if (item.itemType != Item.ItemType.None)
                {
                    Item temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.ShowDraggedItem(temp, -1);
                    PlayerStats.instance.armorGems[0] = item.GemType;
                    PlayerStats.instance.armorGemsTier[0] = item.GemTier;
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.ClosedDraggedItem();
                    PlayerStats.instance.armorGems[0] = item.GemType;
                    PlayerStats.instance.armorGemsTier[0] = item.GemTier;
                }
            }
            if (index == 1 && inventory.draggedItem.itemType == Item.ItemType.Gem)
            {
                if (item.itemType != Item.ItemType.None)
                {
                    Item temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.ShowDraggedItem(temp, -1);
                    PlayerStats.instance.armorGems[1] = item.GemType;
                    PlayerStats.instance.armorGemsTier[1] = item.GemTier;
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.ClosedDraggedItem();
                    PlayerStats.instance.armorGems[1] = item.GemType;
                    PlayerStats.instance.armorGemsTier[1] = item.GemTier;
                }
            }

            if (index == 2 && inventory.draggedItem.itemType == Item.ItemType.Gem)
            {
                if (item.itemType != Item.ItemType.None)
                {
                    Item temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.ShowDraggedItem(temp, -1);
                    PlayerStats.instance.armorGems[2] = item.GemType;
                    PlayerStats.instance.armorGemsTier[2] = item.GemTier;
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.ClosedDraggedItem();
                    PlayerStats.instance.armorGems[2] = item.GemType;
                    PlayerStats.instance.armorGemsTier[2] = item.GemTier;
                }
            }

            if (index == 3 && inventory.draggedItem.itemType == Item.ItemType.Gem)
            {
                if (item.itemType != Item.ItemType.None)
                {
                    Item temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.ShowDraggedItem(temp, -1);
                    PlayerStats.instance.pickaxeGems[0] = item.GemType;
                    PlayerStats.instance.pickaxeGemsTier[0] = item.GemTier;
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.ClosedDraggedItem();
                    PlayerStats.instance.pickaxeGems[0] = item.GemType;
                    PlayerStats.instance.pickaxeGemsTier[0] = item.GemTier;
                    quest1.gemas++;
                }
            }

            if (index == 4 && inventory.draggedItem.itemType == Item.ItemType.Gem)
            {
                if (item.itemType != Item.ItemType.None)
                {
                    Item temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.ShowDraggedItem(temp, -1);
                    PlayerStats.instance.pickaxeGems[1] = item.GemType;
                    PlayerStats.instance.pickaxeGemsTier[1] = item.GemTier;
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.ClosedDraggedItem();
                    PlayerStats.instance.pickaxeGems[1] = item.GemType;
                    PlayerStats.instance.pickaxeGemsTier[1] = item.GemTier;
                    quest1.gemas++;
                }
            }

            if (index == 5 && inventory.draggedItem.itemType == Item.ItemType.Gem)
            {
                if (item.itemType != Item.ItemType.None)
                {
                    Item temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.ShowDraggedItem(temp, -1);
                    PlayerStats.instance.pickaxeGems[2] = item.GemType;
                    PlayerStats.instance.pickaxeGemsTier[2] = item.GemTier;
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.ClosedDraggedItem();
                    PlayerStats.instance.pickaxeGems[2] = item.GemType;
                    PlayerStats.instance.pickaxeGemsTier[2] = item.GemTier;
                    quest1.gemas++;
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item.itemType != Item.ItemType.None)
        {
            inventory.draggedItem = item;
            inventory.ShowDraggedItem(item, -1);
            InventoryStats.instance.items[item.itemID]++;
            item = new Item();
            if(armor)
            {
                PlayerStats.instance.armorGems[indexI] = 0;
                PlayerStats.instance.armorGemsTier[indexI] = 0;
            }
            else
            {
                PlayerStats.instance.pickaxeGems[indexI] = 0;
                PlayerStats.instance.pickaxeGemsTier[indexI] = 0;
            }
        }
    }
}
