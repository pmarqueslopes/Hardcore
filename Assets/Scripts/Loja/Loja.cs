using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loja : MonoBehaviour
{
    public Canvas canvas3D;
    public GameObject potionShop;
    public GameObject[] prefabs;
    public GameObject Drop;
    bool areaLoja = false;
    public static Loja instance { get; private set;}

    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas3D.gameObject.SetActive(true);
            areaLoja = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            potionShop.SetActive(false);
            canvas3D.gameObject.SetActive(false);
            areaLoja = false;
        }
    }

    public void Sell(int id)
    {
        Instantiate(prefabs[id], Drop.transform.position, Drop.transform.rotation);
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && areaLoja == true)
        {
            if (potionShop.active == true)
            {
                potionShop.SetActive(false);
            }
            else
            {
                potionShop.SetActive(true);
            }
        }
    }
}
