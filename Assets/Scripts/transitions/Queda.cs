using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queda : MonoBehaviour
{
    public Transform spawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = spawn.position;
        }
    }
}
