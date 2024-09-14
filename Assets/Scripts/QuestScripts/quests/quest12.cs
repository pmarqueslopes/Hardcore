using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest12 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int areaVerde;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (areaVerde == 1)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if(areaVerde >= 1)
        {
            areaVerde = 1;
        }
    }

}
