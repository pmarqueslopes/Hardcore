using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest3 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int cristalV;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (cristalV == 2)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if(cristalV >= 2)
        {
            cristalV = 2;
        }
    }

}
