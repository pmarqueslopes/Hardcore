using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemInBox : MonoBehaviour, IPointerDownHandler
{
    public Item item;
    public int index;
    Inventory inventory;
    DropBox dropBox;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        dropBox = GameObject.FindGameObjectWithTag("DropBox").GetComponent<DropBox>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        inventory.AddExistingItem(item);
        Destroy(dropBox.listItemBox[index]);
        dropBox.listItemBox.RemoveAt(index);
        Destroy(dropBox.nearUs[index]);
        dropBox.nearUs.RemoveAt(index);
        dropBox.UpdateIndexOfTheBoxes();
    }

    
}
