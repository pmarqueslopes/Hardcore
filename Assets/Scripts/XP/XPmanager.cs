using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPmanager : MonoBehaviour
{
    public static XPmanager Instance { get; private set; }
    public int currentLVL;
    public int currentXP, maxXP;

    public bool drop;

  
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void AddXP(int xp)
    {
        currentXP += xp;
        if (currentXP >= maxXP)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentLVL++;
        int rest = currentXP - maxXP;
        currentXP = 0 + rest;
        maxXP += 20;
        Debug.Log("LEvel UP");
    }
  
}