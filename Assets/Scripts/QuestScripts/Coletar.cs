using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coletar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            if (this.CompareTag("CristalAzul"))
            {
                Destroy(this.gameObject);
                quest8.cristalA++;
            }
            if (this.CompareTag("CristalVermelho"))
            {
                Destroy(this.gameObject);
                quest3.cristalV++;
            }
            if (this.CompareTag("CristalVerde"))
            {
                Destroy(this.gameObject);
                quest13.cristalVerde++;
            }

        }
    }
}
