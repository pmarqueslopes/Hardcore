using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest10 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int ultimateUses;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (ultimateUses == 3)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if(ultimateUses >= 3) {
            ultimateUses = 3;
        }
    }

}
