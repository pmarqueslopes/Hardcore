using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWorlddddddd : MonoBehaviour
{
    public Transform destino;

    public void LoadWorldd()
    {
        SceneManager.LoadScene("World");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.position = destino.transform.position;
        }
    }

}
