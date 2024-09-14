using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest13 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int cristalVerde;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (cristalVerde == 4)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if (cristalVerde >= 4)
        {
            cristalVerde = 4;
        }
    }

}
