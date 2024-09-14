using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string nomeCena;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nomeCena);
            if(nomeCena == "AreaVermelha")
            {
                quest2.areaV++;
            }
            if (nomeCena == "AreaAzul")
            {
                quest7.areaA++;
            }
            if (nomeCena == "AreaVerde")
            {
                quest12.areaVerde++;
            }
        }
    }
}
