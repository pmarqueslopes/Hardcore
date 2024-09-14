using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropBox : MonoBehaviour, IPointerDownHandler
{
    Inventory inventory;

    public GameObject[]droppedItem;
    public List<GameObject> nearUs = new List<GameObject>();
    public GameObject itemBox;
    public List<GameObject> listItemBox = new List<GameObject>();
    public Transform dropPoint;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }


    void Update()
    {
        droppedItem = GameObject.FindGameObjectsWithTag("Item");
        GetDroppedItemsInRange();
        CheckIfItemItStillInRange();
    }

    void UpdateItemBoxPosition()
    {
        for(int i = 0; i < listItemBox.Count; i++)
        {
            Vector3 pos = new Vector3(0, (-100 * i ) + 315, 0);
            listItemBox[i].GetComponent<RectTransform>().localPosition = pos;
        }
        
    }

    void CheckIfItemItStillInRange()
    {
        for(int i = 0; i < nearUs.Count; i++)
        {
            float distance = 100000000;
            if(nearUs[i] != null)
            {
                distance = Vector3.Distance(nearUs[i].transform.position,GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            if(distance > 3)
            {
                Destroy(listItemBox[i]);
                listItemBox.RemoveAt(i);
                nearUs.RemoveAt(i);
                UpdateItemBoxPosition();
            }
        }
    }

    void GetDroppedItemsInRange()
    {
        for(int i = 0; i < droppedItem.Length; i++)
        {
            float distance = Vector3.Distance(droppedItem[i].transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
            if(distance <= 3)
            {
               Item item = droppedItem[i].GetComponent<DroppedItem>().item;
               if(nearUs.Count == 0)
               {
                  nearUs.Add(droppedItem[i]);
                  CreateItemsInBox();
               }
               else
               {
                  bool temp = false;
                  for(int k = 0; k < nearUs.Count; k++)
                  {
                     if(nearUs[k] != null)
                     {
                        if(nearUs[k].GetComponent<DroppedItem>().item.Equals(item));
                        {
                            temp = true;
                        }
                        if(!temp && k == nearUs.Count - 1)
                        {
                            nearUs.Add(droppedItem[i]);
                            CreateItemsInBox();
                        }
                     } 
                  }
               }                 
            }
        }
    }

    public void CreateItemsInBox()
    {
            Vector3 pos = new Vector3(0, (-100 * listItemBox.Count) + 315, 0);
            GameObject item = (GameObject)Instantiate(itemBox);
            
            ItemInBox boxWithItem = item.GetComponent<ItemInBox>();
            boxWithItem.index = listItemBox.Count;
            boxWithItem.item = nearUs[listItemBox.Count].GetComponent<DroppedItem>().item;

            listItemBox.Add(item);
            item.transform.parent = this.gameObject.transform;
            item.GetComponent<RectTransform>().localPosition = pos;
            item.transform.GetChild(0).GetComponent<Image>().sprite = nearUs[listItemBox.Count - 1].GetComponent<DroppedItem>().item.itemIcon;
            item.transform.GetChild(1).GetComponent<TMP_Text>().text = nearUs[listItemBox.Count - 1].GetComponent<DroppedItem>().item.itemName;
            if (nearUs[listItemBox.Count - 1].GetComponent<DroppedItem>().item.itemType == Item.ItemType.Consumable)
            {
                item.transform.GetChild(2).GetComponent<TMP_Text>().enabled = true;
                item.transform.GetChild(2).GetComponent<TMP_Text>().text = "x" + nearUs[listItemBox.Count - 1].GetComponent<DroppedItem>().item.itemValue;
            }

        
    }

    public void UpdateIndexOfTheBoxes()
    {
        for(int i =0; i < listItemBox.Count; i++)
        {
            listItemBox[i].GetComponent<ItemInBox>().index = i;
            
        }
    }
    
    void DropItem(Item item)// Change the point that the object spawn
    {
        GameObject itemAsGameObject = (GameObject)Instantiate(item.itemModel, dropPoint.transform.position, Quaternion.identity);
        itemAsGameObject.GetComponent<DroppedItem>().item = item;
    }

     public void OnPointerDown(PointerEventData eventData)
    {
        if(inventory.draggingItem)
        {   
            DropItem(inventory.draggedItem);
            inventory.ClosedDraggedItem();
        }
    }

}
