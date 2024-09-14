using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubStart : MonoBehaviour
{   public static HubStart instance { get; private set; }
   
   public GameObject player;
   public Transform spawn;
   public PlayerMovement movement;

   public GameObject[] UIgema1;
   public GameObject[] UIgema2;
   public GameObject[] UIgema3;
   private void Awake()
   {
      instance = this;
      player.transform.position = spawn.transform.position;

   }

   

   private void Start()
   {
      
      CombatTransition.instance.playerPosition = new Vector3(0, 0, 0);

   }

   public void EnableMovement()
   {
      movement.enabled = true;
   }

   public void DisableMovement()
   {
      movement.enabled = false;
   }
  
}
