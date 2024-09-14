using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest14 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int batalhaV;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (batalhaV == 3)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if(batalhaV >= 3) { 
            batalhaV = 3;
        }
    }

}

