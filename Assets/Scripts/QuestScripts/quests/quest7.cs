using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest7 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int areaA;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (areaA == 1)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if(areaA >= 1)
        {
            areaA = 1;
        }
    }

}
