using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest16 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int batalhabossVerde;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (batalhabossVerde == 1)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if(batalhabossVerde >= 1)
        {
            batalhabossVerde = 1;
        }
    }

}