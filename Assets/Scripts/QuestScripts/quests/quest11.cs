using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest11 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int batalhabossA;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (batalhabossA == 1)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if(batalhabossA >= 1)
        {
            batalhabossA = 1;
        }
    }

}