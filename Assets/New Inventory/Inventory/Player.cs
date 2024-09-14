using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Inventory inventoryScript;
    GameObject inventory;
    GameObject equipSystem;
    bool showInventory = false;
    bool inEquipSystemRange = false;

    void Start()
    {
        inventoryScript = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        inventory = GameObject.FindGameObjectWithTag("AllInventory");
        equipSystem = GameObject.FindGameObjectWithTag("Equip System");
        inventory.SetActive(false);
        equipSystem.SetActive(false);


    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            showInventory = !showInventory;
            inventory.SetActive(showInventory);
        }

        if (Input.GetKeyDown(KeyCode.I) && inEquipSystemRange == true)
        {
            showInventory = !showInventory;
            inventory.SetActive(showInventory);
            inEquipSystemRange = !inEquipSystemRange;
            equipSystem.SetActive(inEquipSystemRange);

        }


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                float distance = Vector3.Distance(hit.transform.position, this.transform.position);
                
                if(hit.transform.tag == "Item" && distance <= 3)
                {
                    inventoryScript.AddExistingItem(hit.transform.GetComponent<DroppedItem>().item);
                    Destroy(hit.transform.gameObject );
                }
            }
        }

        void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.tag == "Forge")
            {
                inEquipSystemRange = true;
                Debug.Log("colidindo");
            }
        }

        void OnTriggerExit(Collider col)
        {
            if (col.gameObject.tag == "Forge")
            {
                inEquipSystemRange = false;
                Debug.Log("sai do colisor");
            }
        }
    }
}
