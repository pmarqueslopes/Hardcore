using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class Inventory : MonoBehaviour
{
    public List<GameObject> Slots = new List<GameObject>();
    public List<Item> Items = new List<Item>();
    ItemDataBase dataBase;
    public GameObject slots;
    public GameObject tooltip;
    public GameObject draggedItemGameObject;
    public bool draggingItem = false;
    public Item draggedItem;
    public int indexOfDraggedItem;
    public Button btn;
    
    
    void Start()
    {
        tooltip.SetActive(false);
        int slotAmount = 0;
        dataBase = GameObject.FindGameObjectWithTag("ItemDataBase").GetComponent<ItemDataBase>();
        //Create the inventory cells
        int x = -260;
        int y = 280;

        for(int i = 1; i < 5; i++)
        {
            for(int k = 1; k < 5; k++)
            {
                GameObject slot = (GameObject)Instantiate(slots);
                slot.GetComponent<SlotScript>().slotNumber = slotAmount;
                Slots.Add(slot);
                Items.Add(new Item());
                slot.transform.parent = this.gameObject.transform;
                slot.name = "Slot" + i + "." + k;
                slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
                x = x + 173;
                if( k == 4)
                {
                   x = - 260;
                   y = y - 187; 
                }
                slotAmount++;
            }
        }
        
         StartInventory();
       
    }

    void StartInventory()
    {
        if (InventoryStats.instance.items[0] > 0)
        {
            for (int i = 0; i < InventoryStats.instance.items[0]; i++)
            {   
                AddItem(0);
            }
        }
        if (InventoryStats.instance.items[1] > 0)
        {
            for (int i = 0; i < InventoryStats.instance.items[1]; i++)
            {   
                AddItem(1);
            }
            
        }
        if (InventoryStats.instance.items[2] > 0)
        {
            for (int i = 0; i < InventoryStats.instance.items[2]; i++)
            {   
                AddItem(2);
            }
        }
        if (InventoryStats.instance.items[3] > 0)
        {
            for (int i = 0; i < InventoryStats.instance.items[3]; i++)
            {   
                AddItem(3);
            }
        }
        if (InventoryStats.instance.items[4] > 0)
        {
            for (int i = 0; i < InventoryStats.instance.items[4]; i++)
            {   
                AddItem(4);
            }
            
        }
        if (InventoryStats.instance.items[5] > 0)
        {
            for (int i = 0; i < InventoryStats.instance.items[5]; i++)
            {   
                AddItem(5);
            }
        }
        if (InventoryStats.instance.items[6] > 0)
        {
            for (int i = 0; i < InventoryStats.instance.items[6]; i++)
            {   
                AddItem(6);
            }
        }
        if (InventoryStats.instance.items[7] > 0)
        {
            for (int i = 0; i < InventoryStats.instance.items[7]; i++)
            {   
                AddItem(7);
            }
            
        }
        if (InventoryStats.instance.items[8] > 0)
        {
            for (int i = 0; i < InventoryStats.instance.items[8]; i++)
            {   
                AddItem(8);
            }
        }
        if (InventoryStats.instance.items[9] > 0)
        {
            for (int i = 0; i < InventoryStats.instance.items[9]; i++)
            {   
                AddItem(9);
            }
        }
        if (InventoryStats.instance.items[10] > 0)
        {
            for (int i = 0; i < InventoryStats.instance.items[10]; i++)
            {   
                AddItem(10);
            }
        }
        
    }
    void Update()
    {
        if (draggingItem)//Solve the position the icon is activated
        {
            Vector3 pos = (Input.mousePosition - GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>().localPosition);
            draggedItemGameObject.GetComponent<RectTransform>().localPosition = new Vector3(pos.x+35 , pos.y+20 , pos.z); 
           
        }
    }

    void AddItem(int id)
    {   
        for(int i = 0; i < dataBase.items.Count; i++)
        {
            if(dataBase.items[i].itemID == id)
            {
                Item item = dataBase.items[i];
                
                if(dataBase.items[i].itemType == Item.ItemType.Consumable)
                {
                    CheckIfItemExists(id, item);
                    
                    break;
                }
                else
                {   
                    AddItemAtEmptySlot(item);
                    
                }
            }
        }

    }

    void AddItemAtEmptySlot(Item item)
    {
        for( int i = 0; i < Items.Count; i++)
        {
            if(Items[i].itemName == null)
            {   
                Items[i] = item;
                
                break;
            }
        }
    }

    public void AddExistingItem(Item item)
    {
        if(item.itemType == Item.ItemType.Consumable)
        {
            CheckIfItemExists(item.itemID, item);
            
        }
        else
        {
            AddItemAtEmptySlot(item);
            
            InventoryStats.instance.items[item.itemID]++;
        }
    }
    
    public void ShowTooltip(Vector3 toolPosition, Item item)
    {
        tooltip.SetActive(true);
        tooltip.GetComponent<RectTransform>().localPosition = new Vector3(toolPosition.x + 80, toolPosition.y, toolPosition.z);//tooltip position
        tooltip.transform.GetChild(0).GetComponent<TMP_Text>().text = item.itemName;
        tooltip.transform.GetChild(2).GetComponent<TMP_Text>().text = item.itemDesc;
        

    }

    public void CloseTooltip()
    {
        tooltip.SetActive(false);
    }

    public void ShowDraggedItem(Item item, int slotnumber)
    {
        indexOfDraggedItem = slotnumber;
        CloseTooltip();
        draggedItemGameObject.SetActive(true);
        draggedItem = item;
        draggingItem = true;
        draggedItemGameObject.GetComponent<Image>().sprite = item.itemIcon;
        Debug.Log("Tirou");
        InventoryStats.instance.items[item.itemID]--;
    }

    public void ClosedDraggedItem()
    {
        draggingItem = false;
        draggedItemGameObject.SetActive(false);
       
        
    }
    
    public void CheckIfItemExists(int itemID, Item item)
    {
        for(int i = 0; i < Items.Count; i++)
        {
            if(Items[i].itemID == itemID)
            {
                Items[i].itemValue = Items[i].itemValue + item.itemValue;
                
                break;
                
            }
            else if( i == Items.Count - 1)
            {   
                AddItemAtEmptySlot(item);
                
                
            }
        }
    }

  

}
