using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quest6 : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public GameObject button;
    public static int batalhaboss;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (batalhaboss == 1)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
        if(batalhaboss >= 1)
        {
            batalhaboss = 1;
        }
    }

}