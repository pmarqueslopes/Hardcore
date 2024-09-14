using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance { get; private set;}
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

    
    public float damage;
    public float currentHp;
    public float maxHp;
    public float armor;
    public int level;
    public float fury;
    public float singleCost;
    public float multipleCost;
    public float powerSingleCost;
    public float ultimateCost;

    public int[] pickaxeGems = new int[3];
    public int[] pickaxeGemsTier = new int[3];
    public int[] armorGems = new int[3];
    public int[] armorGemsTier = new int[3];







}
