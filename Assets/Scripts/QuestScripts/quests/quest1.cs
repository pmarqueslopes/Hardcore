using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest1 : MonoBehaviour
{
    
    public TextMeshProUGUI texto;
    public GameObject button;
    public static int gemas;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (gemas == 3)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if (gemas >= 3)
        {
            gemas = 3;
        }
    }

}
