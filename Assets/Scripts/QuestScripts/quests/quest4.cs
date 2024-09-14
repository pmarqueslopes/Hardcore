using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest4 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int batalha;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (batalha == 1)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if(batalha >= 1) { 
            batalha = 1;
        }
    }

}

