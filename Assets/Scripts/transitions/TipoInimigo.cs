using System;
using UnityEngine;

public class TipoInimigo : MonoBehaviour
{
    public static TipoInimigo TI { get; private set; }
    public int tipoInimigo1;
    public int tipoInimigo2;
    public bool bossBool;

    private void Awake()
    {   if (TI != null && TI != this)
        {
            Destroy(gameObject);
        }
        else
        {
            TI = this;
        }
        DontDestroyOnLoad(this.gameObject);
      
    }
}