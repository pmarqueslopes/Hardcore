using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest8 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int cristalA;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (cristalA == 3)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if (cristalA >= 3)
        {
            cristalA = 3;
        }
    }

}
