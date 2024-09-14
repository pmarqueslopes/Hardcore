using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTable : MonoBehaviour
{
    public Canvas canvas3D;
    bool areaCraft = false;
    public Image equipSystem;
    public GameObject[] imagensEquip;
    public PlayerManager pm;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            pm.DesactivateInventory();
            canvas3D.gameObject.SetActive(true);
            areaCraft = true;
            pm.crafting = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas3D.gameObject.SetActive(false);
            areaCraft = false;
            equipSystem.enabled = false;
            for (int i = 0; i < imagensEquip.Length; i++)
            {
                imagensEquip[i].SetActive(false);
            }
            pm.DesactivateInventory();
            pm.crafting = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && areaCraft == true)
        {
            if(equipSystem.enabled == true)
            {
                pm.DesactivateInventory();
                equipSystem.enabled = false;
                //areaCraft = false;
                
                for (int i = 0; i < imagensEquip.Length; i++)
                {
                    imagensEquip[i].SetActive(false);
                }
            }
            else
            {
                pm.ActivateInventory();   
                equipSystem.enabled = true;
                //areaCraft = true;
                for (int i = 0; i < imagensEquip.Length; i++)
                {
                    imagensEquip[i].SetActive(true);
                }
            }
        }
    }
}
