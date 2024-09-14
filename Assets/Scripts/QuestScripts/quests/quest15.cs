using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest15 : MonoBehaviour
{
    
    public TextMeshProUGUI texto;
    public GameObject button;
    public static int gemasI;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (gemasI == 3)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if (gemasI >= 3)
        {
            gemasI = 3;
        }
    }

}
