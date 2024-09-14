using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoGema : MonoBehaviour
{
    public int tipogema;
    public int array;
    public int tier;
    public GameObject[] gemaUI;

    public void SetGem()
    {   
        PlayerStats.instance.pickaxeGems[array] = tipogema;
        PlayerStats.instance.pickaxeGemsTier[array] = tier;
        for (int i = 0; i < gemaUI.Length; i++)
        {
            gemaUI[i].SetActive(false);
        }

        gemaUI[tipogema].SetActive(true);
        quest1.gemas++;
        quest15.gemasI++;

    }

    public void SetArmor()
    {
        PlayerStats.instance.armorGems[array] = tipogema;
        PlayerStats.instance.armorGemsTier[array] = tier;
        for (int i = 0; i < gemaUI.Length; i++)
        {
            gemaUI[i].SetActive(false);
        }

        gemaUI[tipogema].SetActive(true);
    }

    public void ClearGem()
    {
        PlayerStats.instance.pickaxeGems[array] = 0;
        for (int i = 0; i < 3; i++)
        {   
            gemaUI[i].SetActive(false);
        }
    }
}
