using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quest1 : MonoBehaviour
{
    
    public Text texto;
    public GameObject button;


    void Start()
    {
        //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (texto)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
    }

    public void Coleta()
    {
        
    }
}
