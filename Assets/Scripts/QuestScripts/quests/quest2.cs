using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest2 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int areaV;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (areaV == 1)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if(areaV >= 1) {
            areaV = 1;
        }
    }

}
