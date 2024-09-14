using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{
    public Item item;
    Image itemImage;
    public int slotNumber;
    Inventory inventory;
    TMP_Text itemAmount;

    IEnumerator inventoryItem()
    {
        yield return new WaitForSeconds(.5f);
        InventoryStats.instance.items[item.itemID]++;
    }
    void Start()
    {
        itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        itemAmount = gameObject.transform.GetChild(1).GetComponent<TMP_Text>();
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(inventory.Items[slotNumber].itemName != null)
        {
            itemAmount.enabled = false;

            item = inventory.Items[slotNumber];
            itemImage.enabled = true;
            itemImage.sprite = inventory.Items[slotNumber].itemIcon;

            if(inventory.Items[slotNumber].itemType == Item.ItemType.Consumable)
            {
                itemAmount.enabled = true;
                itemAmount.text = "" + inventory.Items[slotNumber].itemValue;
            }
        }
        else
        {
            itemImage.enabled = false;
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        if(data.button == PointerEventData.InputButton.Right)
        {
            if(inventory.Items[slotNumber].itemType == Item.ItemType.Consumable)
            {
                inventory.Items[slotNumber].itemValue--;
                if(inventory.Items[slotNumber].itemValue == 0)
                {   
                    inventory.Items[slotNumber] = new Item();
                    
                    itemAmount.enabled = false;
                    inventory.CloseTooltip();
                    
                }

            }
        }

        if(inventory.Items[slotNumber].itemName == null)
        {   
            if(inventory.draggingItem)
            {   
                inventory.Items[slotNumber] = inventory.draggedItem;
                inventory.ClosedDraggedItem();
                StartCoroutine(inventoryItem());
            }
        }
        else 
        {
             try
             {
                // if(inventory.draggingItem)
                // {
                //     if(inventory.Items[slotNumber].itemName != null)
                //    {
                //        inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
                //        inventory.Items[slotNumber] = inventory.draggedItem;
                //        
                //        inventory.ClosedDraggedItem();
                //    }
                // }
             }
            catch{ }
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if(inventory.Items[slotNumber].itemName != null && !inventory.draggingItem)
        {
            inventory.ShowTooltip(inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition, inventory.Items[slotNumber]);
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        if(inventory.Items[slotNumber].itemName != null)
            inventory.CloseTooltip();
    }

    public void OnDrag(PointerEventData data)
    {
        
        if(!inventory.draggingItem && data.button == PointerEventData.InputButton.Left)
        {
            // if(inventory.Items[slotNumber].itemType == Item.ItemType.Consumable)
            // {
            //     inventory.Items[slotNumber].itemValue++;
            // }

            if(inventory.Items[slotNumber].itemName != null)
            {
                inventory.ShowDraggedItem(inventory.Items[slotNumber], slotNumber);
                inventory.Items[slotNumber] = new Item();

                itemAmount.enabled = false;
            }
        }
    }
}
