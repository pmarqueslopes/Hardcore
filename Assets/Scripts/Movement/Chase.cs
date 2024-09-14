using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Chase : MonoBehaviour
{
    public Transform player;
    public float speed;
    public Rigidbody m_Rigidbody;
    private void Awake()
    {
        enabled = false;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       transform.LookAt(player);
       m_Rigidbody.velocity = transform.forward * speed;
    }
}
