using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BattleHUD : MonoBehaviour
{
   public Text nameText;
   public Text leveltext;
   public Slider hpSlider;
   public GameObject HUD;
   public TMP_Text enemyTxt;
   public TMP_Text enemyPowerTxt;
   public GameObject poison;
   public GameObject debuffDmg;
   public GameObject debuffArmor;
   public GameObject debuffHeal;
   public GameObject buffDmg;
   public GameObject buffArmor;






   public void SetEnemyDebuffs(Unit unit)
   {
      if (unit.buffDmgRounds > 0)
      {
         buffDmg.SetActive(true);
      }
      else
      {
         buffDmg.SetActive(false);
      }

      if (unit.buffArmorRounds > 0)
      {
         buffArmor.SetActive(true);
      }
      else
      {
         buffArmor.SetActive(false);
      }

      if (unit.poisonRounds > 0)
      {
         poison.SetActive(true);
         unit.poisonPT.SetActive(true);
      }
      else
      {
         poison.SetActive(false);
      }

      if (unit.debuffDmgRounds > 0)
      {
         debuffDmg.SetActive(true);
         unit.poisonPT.SetActive(false);
      }
      else
      {
         debuffDmg.SetActive(false);
      }

      if (unit.debuffArmorRounds > 0)
      {
         debuffArmor.SetActive(true);
      }
      else
      {
         debuffArmor.SetActive(false);
      }

      if (unit.debuffHeal > 0)
      {
         debuffHeal.SetActive(true);
      }
      else
      {
         debuffHeal.SetActive(false);
      }
       
      
   }

   public void SetBuffs(PlayerUnit player)
   {
      if (player.BuffDmgRounds > 0)
      {
         buffDmg.SetActive(true);
      }
      else
      {
         buffDmg.SetActive(false);
      }

      if (player.buffArmorRounds > 0)
      {
         buffArmor.SetActive(true);
      }
      else
      {
         buffArmor.SetActive(false);
      }

      if (player.poisonRounds > 0)
      {
         poison.SetActive(true);
         player.venenoPT.SetActive(true);
      }
      else
      {
         poison.SetActive(false);
         player.venenoPT.SetActive(false);
      }

      if (player.debuffDmgRounds > 0)
      {
         debuffDmg.SetActive(true);
      }
      else
      {
         debuffDmg.SetActive(false);
      }

      if (player.debuffArmorRounds > 0)
      {
         debuffArmor.SetActive(true);
      }
      else
      {
         debuffArmor.SetActive(false);
      }

      if (player.debuffHeal > 0)
      {
         debuffHeal.SetActive(true);
      }
      else
      {
         debuffHeal.SetActive(false);
      }
      
       
   }
   public void SetEnemyHUD(Unit unit)
   {
      nameText.text = unit.unitName;
      leveltext.text = "Lvl " + unit.level;
      hpSlider.maxValue = unit.maxHP;
      hpSlider.value = unit.currentHP;
      enemyTxt.text = unit.unitName;
      enemyPowerTxt.text = unit.unitName;
      

   }
   public void SetPlayerHUD(PlayerUnit playerUnit)
   {
      nameText.text = playerUnit.unitName;
      leveltext.text = "Lvl " + playerUnit.level;
      hpSlider.maxValue = playerUnit.maxHP;
      hpSlider.value = playerUnit.currentHP;

   }

   public void SetHP(float hp)
   {
      hpSlider.value = hp;

      if (hp <= 0)
      {
         StartCoroutine(DeactivateHud());
      }
   }

   IEnumerator DeactivateHud()
   {
      yield return new WaitForSeconds(2);
      HUD.SetActive(false);
   }

   public void BossDeactivate()
   {
      HUD.SetActive(false);
   }


}
