using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int level;
    public int baseArmor; // maximo de armor
    public float armor; // armor atual do inimigo
    public float maxHP;
    public float currentHP;
    public bool isAlive = true;
    public string Element;
    public string weakGem;
    public string strongGem;
    public int poisonDmg;
    public int poisonRounds;
    public int debuffDmgRounds;
    public int debuffArmorRounds;
    public int buffDmgRounds;
    public int buffArmorRounds;
    public int debuffHeal;
    public float buffArmorValue =1;
    public float debuffArmorValue=1;

    public GameObject poisonPT;

    public List<BaseAttack> attacks = new List<BaseAttack>();
    public int waitTime;

    private void Start()
    {
        armor = baseArmor;
        buffArmorValue = 1;
        debuffArmorValue = 1;
    }

    public void Attack(PlayerUnit playerUnit, Unit unit)
    {   
        int rnd = Random.Range(0, attacks.Count);
        StartCoroutine(attacks[rnd].Attack(playerUnit, unit));
        // int time = attacks[rnd].WaitTime();

    }
    float Damage( float dmg)
    {
        if (armor >= dmg)
        {
            currentHP -= 1;
        }
        else
        {
            currentHP -= dmg - armor;
        }
        
        return currentHP;
    }
    

     float CheckGem(string gem,float dmg)
    {
        if(weakGem == gem)
        {
            dmg *= 2; 
               
        }
        else if (strongGem == gem)
        {
            dmg /= 2;

        }
        else dmg = dmg;

       
        return dmg;

    }

    float CheckDebuffArmor(float armor)
    {
        armor = baseArmor;
        if (buffArmorRounds <= 0)
        {
            buffArmorValue = 1;
        }
        if (debuffArmorRounds <= 0)
        {
            debuffArmorValue = 1;
        }
        
        armor *= debuffArmorValue;
        armor *= buffArmorValue;
        
        return armor;
        
    }

    float CheckPlayerDmg(float dmg,PlayerUnit pUnit)
    {
        if (pUnit.debuffDmgRounds > 0)
        {
            dmg /= 2;
        }

        if (pUnit.BuffDmgRounds > 0)
        {
            dmg *= pUnit.buffattackst;
        }
        
        return dmg;
        

    }

    void CheckAlive()
    {
        if (currentHP <= 0&& isAlive ==true)
        {
            isAlive = false;
           
            BattleSystem.BS.aliveEnemies--;
            StartCoroutine(Die());

        }
    }

    IEnumerator Die()
    {   
        BattleSystem.BS.startText.text = name + " foi derrotado ";
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }
    

  
    public void TakeDamageSingle(float dmg, string gem, PlayerUnit pUnit)
    {
       armor = CheckDebuffArmor(armor);
      
       dmg = CheckPlayerDmg(dmg ,pUnit);
       
       dmg = CheckGem(gem,dmg);
       
        
        if (gem == "Red")
        {    if (pUnit.debuffHeal > 0)
            {
                pUnit.currentHP += (dmg*pUnit.healssinglest)/2;
                
            }
            else
            {
                pUnit.currentHP += dmg *pUnit.healssinglest;
            }
           
            if (pUnit.currentHP >= maxHP)
            {
                pUnit.currentHP = maxHP;
            }
            BattleSystem.BS.heal.Play();
        }
        else if (gem == "Green")
        {
            pUnit.buffArmorRounds+=3;
            pUnit.buffArmorValue = pUnit.buffarmorst;


        }
        else if (gem == "Blue")
        {
            debuffDmgRounds+=3;
        }
        
       currentHP =  Damage(dmg);
        
        CheckAlive();
        

    } 
    public void TakeDamageMultiple(float dmg, string gem, PlayerUnit pUnit)
         {   
            armor = CheckDebuffArmor(armor);
            
            dmg = CheckPlayerDmg(dmg ,pUnit);
            dmg = CheckGem(gem,dmg);
     
                 if (gem == "Red")
                 {
                     if (pUnit.debuffHeal > 0)
                     {
                         pUnit.currentHP += (dmg*pUnit.healmultiplest)/2 ;
                     }
                     else
                     {
                         pUnit.currentHP += dmg*pUnit.healmultiplest;
                     }
                     if (pUnit.currentHP >= maxHP)
                     {
                         pUnit.currentHP = maxHP;
                     }
                     BattleSystem.BS.heal.Play();
                 }
                 else if (gem == "Green")
                 {
                     poisonRounds += 2;
                 }
                 else if (gem == "Blue")
                 {
                     debuffArmorRounds+=3;
                     debuffArmorValue = pUnit.debuffarmorst;

                 }
            
                 
                 currentHP = Damage(dmg);
                 
                 
                 CheckAlive();
             
     
         }
    public void TakeDamagePower(float dmg, string gem, PlayerUnit pUnit)
    {
      armor =  CheckDebuffArmor(armor);
      dmg = CheckPlayerDmg(dmg ,pUnit);
       dmg =CheckGem(gem,dmg);

        if (gem == "Red")
        {
            if (pUnit.debuffHeal > 0)
            {
                pUnit.currentHP += (dmg*pUnit.healpowerst)/2;
            }
            else
            {
                pUnit.currentHP += dmg *pUnit.healpowerst;
            }
            if (pUnit.currentHP >= maxHP)
            {
                pUnit.currentHP = maxHP;
            }
            BattleSystem.BS.heal.Play();
        }
        else if (gem == "Green")
        {
            pUnit.BuffDmgRounds +=1; 
            
        }
        else if (gem == "Blue")
        {
            debuffHeal += 1*pUnit.cuthealst;
        }
        
       currentHP= Damage(dmg);
        CheckAlive();
        
    }
    

    public void TakeDamageUlt(float dmg,PlayerUnit pUnit)
    {armor =CheckDebuffArmor(armor);
      dmg = CheckPlayerDmg(dmg ,pUnit);

        switch (pUnit.equipedGemSingle)
        {
            case "Red":  if (pUnit.debuffHeal > 0)
                {
                    pUnit.currentHP += (dmg*pUnit.healssinglest)/2;
                }
                else
                {
                    pUnit.currentHP += dmg *pUnit.healssinglest;
                }
           
                if (pUnit.currentHP >= maxHP)
                {
                    pUnit.currentHP = maxHP;
                }
                BattleSystem.BS.heal.Play();
                break;
            case "Green":  pUnit.buffArmorRounds+=3;
                pUnit.buffArmorValue = pUnit.buffarmorst;
                break;
            case "Blue": debuffDmgRounds+=3;
                break;
        }
        switch (pUnit.equipedGemMultiple)
        {
            case "Red": if (pUnit.debuffHeal > 0)
                {
                    pUnit.currentHP += (dmg*pUnit.healmultiplest)/2 ;
                }
                else
                {
                    pUnit.currentHP += dmg*pUnit.healmultiplest;
                }
                if (pUnit.currentHP >= maxHP)
                {
                    pUnit.currentHP = maxHP;
                }
                BattleSystem.BS.heal.Play();
                break;
            case "Green": poisonRounds+=3; break;
            case "Blue": debuffArmorRounds+=3;
                debuffArmorValue = pUnit.debuffarmorst;
                break;
        }
        switch (pUnit.equipedGemPower)
        {
            case "Red":  if (pUnit.debuffHeal > 0)
                {
                    pUnit.currentHP += (dmg*pUnit.healpowerst)/2;
                }
                else
                {
                    pUnit.currentHP += dmg *pUnit.healpowerst;
                }
                if (pUnit.currentHP >= maxHP)
                {
                    pUnit.currentHP = maxHP;
                }
                BattleSystem.BS.heal.Play();
                break;
            case "Green": pUnit.BuffDmgRounds+=3; break;
            case "Blue":   debuffHeal += 2*pUnit.cuthealst;
                break;
        }
        
       currentHP= Damage(dmg);
        CheckAlive();
        
        
    }

    public void Poison(PlayerUnit punit)
    {   
        if (poisonRounds>0)
        {
            float pdmg = poisonDmg * punit.poisonst;
            currentHP -= pdmg;
            poisonRounds--;
           CheckAlive();

        }
    }
    public void EndTurn()
    {

        if (debuffDmgRounds > 0)
        {
            debuffDmgRounds--;
        }

        if (buffArmorRounds > 0)
        {
            buffArmorRounds--;
        }

        if (buffDmgRounds > 0)
        {
            buffDmgRounds--;
        }

        if (debuffArmorRounds > 0)
        {
            debuffArmorRounds--;
        }

        if (debuffHeal > 0)
        {
            debuffHeal--;
        }
        
    }

}
