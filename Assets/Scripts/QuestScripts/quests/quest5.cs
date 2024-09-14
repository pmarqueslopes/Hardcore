using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest5 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int ultimateUse;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (ultimateUse == 1)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if(ultimateUse >= 1) {
            ultimateUse = 1;
        }
    }

}
