using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public TMP_Text priceTXT;
    public TMP_Text quantityTXT;
   

    private void Start()
    {
        priceTXT.text = "$ " + ShopManager.instance.prices[ItemID].ToString();
        quantityTXT.text = ShopManager.instance.quantities[ItemID].ToString();

    }
    public void Buy()
    {
        if (ShopManager.instance.money >= ShopManager.instance.prices[ItemID]&& ShopManager.instance.quantities[ItemID]>0)
        {
            ShopManager.instance.money -= ShopManager.instance.prices[ItemID];
            ShopManager.instance.quantities[ItemID]--;
            ShopManager.instance.moneyTXT.text = "Coins " + ShopManager.instance.money.ToString();
            quantityTXT.text = ShopManager.instance.quantities[ItemID].ToString();
            Loja.instance.Sell(ItemID);
        }
        else
        {
            return;
        }
    }
}

