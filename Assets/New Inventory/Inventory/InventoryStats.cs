using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryStats : MonoBehaviour
{
    public static InventoryStats instance { get; private set;}
    private void OnEnable()
    {   if (instance != null && instance!= this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
      
    }
    [Header("blue gem 0,1,2; red gem 3,4,5; green gem 6,7,8; health 9; fury 10;")]
    public int[] items;
}
