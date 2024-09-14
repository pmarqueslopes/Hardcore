using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest9 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int batalhaA;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (batalhaA == 2)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if(batalhaA >= 2) { 
            batalhaA = 2;
        }
    }

}

