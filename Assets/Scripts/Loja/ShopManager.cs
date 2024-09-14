using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
   public static ShopManager instance { get; private set;}

   private void Awake()
   {
      instance = this;
   }

   public float money;
   public TMP_Text moneyTXT;
   public int[] prices;
   public int[] quantities;
  
   public void Start()
   {
      moneyTXT.text = "Coins: " + money.ToString();
      
      
   }
}
