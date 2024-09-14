using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatTransition : MonoBehaviour
{

    public bool[] InimigosAzul;
    public bool[] InimigosVermelho;
    public bool[] InimigosVerde;
    public bool BattleWin;
    public int currentenemy;
    public string scene;
    public int xpValue;

   public Vector3 playerPosition;
   
   
   public static CombatTransition instance { get; private set; }

   private void Awake()
   {
     
       if (instance != null && instance != this)
       {
           Destroy(gameObject);
       }
       else
       {
           instance = this;
       }
        
       DontDestroyOnLoad(gameObject);
   }

   
 

   public void DefeatEnemies()
   {
       if (BattleSystem.BS.state == BattleSystem.BattleState.WON)
       {
           switch (scene)
           {
               case "AreaAzul": InimigosAzul[currentenemy] = true;
                   break;
               case "AreaVerde": InimigosVerde[currentenemy] = true;
                   break;
               case "AreaVermelha": InimigosVermelho[currentenemy] = true;
                   break;
               
           }
       }
      
       

   }

  

}
