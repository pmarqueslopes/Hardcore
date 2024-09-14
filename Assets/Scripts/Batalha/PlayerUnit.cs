using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public string unitName;
    public int level;
    public float damageSingle;
    public float damageMultiple;
    public float damagePower;
    public float damageUlt;
    
    
    public int BuffDmgRounds;
    public int buffArmorRounds;
    public int poisonRounds;
    public int debuffDmgRounds;
    public int debuffArmorRounds;
    public int debuffHeal;
    
    public float buffArmorValue=1;
    public float debuffArmorValue=1;

    public float maxHP;
    public float currentHP;
    public float shield =0;//porcentagem
    public float armor;
    public float baseArmor;
    public float fury;
    public int poisonDmg;
    public float singleCost;
    public float multipleCost;
    public float powerSingleCost;
    public float ultimateCost;
    public string equipedGemSingle;
    public string equipedGemMultiple;
    public string equipedGemPower;

    public string equipedGemChest;
    public string equipedGemRHand;
    public string equipedGemLHand;

    public int redArmor;
    public int greenArmor;
    public int blueArmor;
   
    public GameObject venenoPT;

    public float healssinglest;
    public float healmultiplest;
    public float healpowerst;
    public float buffarmorst;
    public float poisonst;
    public float buffattackst;
    public float debuffattackst;
    public float debuffarmorst;
    public int cuthealst;
    public Animator anim;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void EndTurn()
    {
        if (buffArmorRounds>0)
        {
            buffArmorRounds--;
        }

        if (BuffDmgRounds > 0)
        {
            BuffDmgRounds--;
        }

        if (debuffDmgRounds > 0)
        {
            debuffDmgRounds--;
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

    float CheckArmor()
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

    float CheckDmg(Unit unit , float dmg)
    {
        if (unit.debuffDmgRounds > 0)
        {
            dmg *=debuffattackst;
        }

        if (unit.buffDmgRounds > 0)
        {
            dmg *= 1.5f;
        }
        

        return dmg;
    }


   float Damage( float dmg,Unit unit)
   {
       float elementArmor = 0;
       if (unit.Element == "Red")
       {
           elementArmor = redArmor/100f;
       }
       else if (unit.Element == "Green")
       {
           elementArmor = greenArmor/100f;
       }
       else if (unit.Element == "Blue")
       {
           elementArmor = blueArmor/100f;
       }
       
       
        
        if ((armor+elementArmor) >=dmg)
        {
            currentHP -= 1;
        }
        else
        {
            dmg -= armor;
            dmg -= dmg * elementArmor;
            
            currentHP -= dmg;
        }
        
        return currentHP;
        
   }
    
        
   public void Poison()
   {   
       if (poisonRounds>0)
       {
           currentHP -= poisonDmg;
           poisonRounds--;

       }
   }

  
    
    
 public void LoadStats()
 {
        level = XPmanager.Instance.currentLVL;
        int lvlmt = 1+(level/10);
        damageSingle = PlayerStats.instance.damage*lvlmt;
        damageMultiple = damageSingle * 0.75f;
        damagePower = damageSingle * 0.5f;
        damageUlt = damageSingle;
        maxHP = PlayerStats.instance.maxHp *lvlmt;
        currentHP = maxHP;
        
        fury = PlayerStats.instance.fury;
        singleCost = PlayerStats.instance.singleCost;
        multipleCost = PlayerStats.instance.multipleCost;
        powerSingleCost = PlayerStats.instance.powerSingleCost;
        ultimateCost = PlayerStats.instance.ultimateCost;
       LoadGems();
        

    }

 void LoadGems()
 {     
     switch (PlayerStats.instance.pickaxeGems[0])
        {
            case 0:
                equipedGemSingle = "None";
                break;
            case 1:
                equipedGemSingle = "Blue";
                break;
            case 2:
                equipedGemSingle = "Green";
                break;
            case 3:
                equipedGemSingle = "Red";
                break;
        }
        switch (PlayerStats.instance.pickaxeGems[1])
        {
            case 0:
                equipedGemMultiple = "None";
                break;
            case 1:
                equipedGemMultiple = "Blue";
                break;
            case 2:
                equipedGemMultiple = "Green";
                break;
            case 3:
                equipedGemMultiple = "Red";
                break;
        }
        switch (PlayerStats.instance.pickaxeGems[2])
        {
            case 0:
                equipedGemPower = "None";
                break;
            case 1:
                equipedGemPower = "Blue";
                break;
            case 2:
                equipedGemPower = "Green";
                break;
            case 3:
                equipedGemPower = "Red";
                break;
        }
        
        switch (PlayerStats.instance.armorGems[0])
        {
            case 0:
                equipedGemChest = "None";
                break;
            case 1:
                equipedGemChest = "Blue";
                break;
            case 2:
                equipedGemChest = "Green";
                break;
            case 3:
                equipedGemChest = "Red";
                break;
        }
        
        switch (PlayerStats.instance.armorGems[1])
        {
            case 0:
                equipedGemRHand = "None";
                break;
            case 1:
                equipedGemRHand = "Blue";
                break;
            case 2:
                equipedGemRHand = "Green";
                break;
            case 3:
                equipedGemRHand = "Red";
                break;
        }
        
        switch (PlayerStats.instance.armorGems[2])
        {
            case 0:
                equipedGemLHand = "None";
                break;
            case 1:
                equipedGemLHand = "Blue";
                break;
            case 2:
                equipedGemLHand = "Green";
                break;
            case 3:
                equipedGemLHand = "Red";
                break;
        }

        switch (equipedGemChest)
        {
            case "Blue":
                if (PlayerStats.instance.armorGemsTier[0] == 1)
                {
                    redArmor += 10;
                    baseArmor += 1;

                }
                else if (PlayerStats.instance.armorGemsTier[0] == 2)
                {
                    redArmor += 20;
                    baseArmor += 2;
                }
                else if (PlayerStats.instance.armorGemsTier[0] == 3)
                {
                    redArmor += 30;
                    baseArmor += 3;
                }
                break;
            case "Green":
                if (PlayerStats.instance.armorGemsTier[0] == 1)
                {
                    blueArmor += 10;
                    baseArmor += 1;
                }
                else if (PlayerStats.instance.armorGemsTier[0] == 2)
                {
                    blueArmor += 20;
                    baseArmor += 2;
                }
                else if (PlayerStats.instance.armorGemsTier[0] == 3)
                {
                   blueArmor += 30;
                   baseArmor += 3;
                   
                }
                break;
            case "Red":
                if (PlayerStats.instance.armorGemsTier[0] == 1)
                {
                    greenArmor += 10;
                    baseArmor += 1;
                }
                else if (PlayerStats.instance.armorGemsTier[0] == 2)
                {
                    greenArmor += 20;
                    baseArmor += 2;
                }
                else if (PlayerStats.instance.armorGemsTier[0] == 3)
                {
                    greenArmor += 30;
                    baseArmor += 3;
                }
                break;
                
        }
        switch (equipedGemRHand)
        {
            case "Blue":
                if (PlayerStats.instance.armorGemsTier[1] == 1)
                {
                    redArmor += 5;
                    baseArmor += 1;
                }
                else if (PlayerStats.instance.armorGemsTier[1] == 2)
                {
                    redArmor += 10;
                    baseArmor += 2;
                }
                else if (PlayerStats.instance.armorGemsTier[1] == 3)
                {
                    redArmor += 15;
                    baseArmor += 3;
                }
                break;
            case "Green":
                if (PlayerStats.instance.armorGemsTier[1] == 1)
                {
                    blueArmor +=5;
                    baseArmor += 1;
                }
                else if (PlayerStats.instance.armorGemsTier[1] == 2)
                {
                    blueArmor += 10;
                    baseArmor += 2;
                }
                else if (PlayerStats.instance.armorGemsTier[1] == 3)
                {
                    blueArmor += 15;
                    baseArmor += 3;
                }
                break;
            case "Red":
                if (PlayerStats.instance.armorGemsTier[1] == 1)
                {
                    greenArmor += 5;
                    baseArmor += 1;
                }
                else if (PlayerStats.instance.armorGemsTier[1] == 2)
                {
                    greenArmor += 10;
                    baseArmor += 2;
                }
                else if (PlayerStats.instance.armorGemsTier[1] == 3)
                {
                    greenArmor += 15;
                    baseArmor += 3;
                }
                break;
                
        }
        switch (equipedGemLHand)
        {
            case "Blue":
                if (PlayerStats.instance.armorGemsTier[2] == 1)
                {
                    redArmor += 5;
                    baseArmor += 1;
                }
                else if (PlayerStats.instance.armorGemsTier[2] == 2)
                {
                    redArmor += 10;
                    baseArmor += 2;
                }
                else if (PlayerStats.instance.armorGemsTier[2] == 3)
                {
                    redArmor += 15;
                    baseArmor += 3;
                }
                break;
            case "Green":
                if (PlayerStats.instance.armorGemsTier[2] == 1)
                {
                    blueArmor += 5;
                    baseArmor += 1;
                }
                else if (PlayerStats.instance.armorGemsTier[2] == 2)
                {
                    blueArmor += 10;
                    baseArmor += 2;
                }
                else if (PlayerStats.instance.armorGemsTier[2] == 3)
                {
                    blueArmor += 15;
                    baseArmor += 3;
                }
                break;
            case "Red":
                if (PlayerStats.instance.armorGemsTier[2] == 1)
                {
                    greenArmor += 5;
                    baseArmor += 1;
                }
                else if (PlayerStats.instance.armorGemsTier[2] == 2)
                {
                    greenArmor += 10;
                    baseArmor += 2;
                }
                else if (PlayerStats.instance.armorGemsTier[2] == 3)
                {
                    greenArmor += 15;
                    baseArmor += 3;
                }
                break;
                
        }

        switch (equipedGemSingle)
        {
            case "Blue":
                if (PlayerStats.instance.pickaxeGemsTier[0] == 1)
                {
                    debuffattackst = 0.75f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[0] == 2)
                {
                    debuffattackst = 0.5f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[0] == 3)
                {
                    debuffattackst=0.25f;
                }
                break;
            case "Green":
                if (PlayerStats.instance.pickaxeGemsTier[0] == 1)
                {
                    buffarmorst = 1.25f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[0] == 2)
                {
                    buffarmorst = 1.30f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[0] == 3)
                {
                    buffarmorst = 1.50f;
                }
                break;
            case "Red":
                if (PlayerStats.instance.pickaxeGemsTier[0] == 1)
                {
                    healssinglest = .3f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[0] == 2)
                {
                    healssinglest = .4f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[0] == 3)
                {
                    healssinglest = .6f;
                }
                break;
                
        }
        switch (equipedGemMultiple)
        {
            case "Blue":
                if (PlayerStats.instance.pickaxeGemsTier[1] == 1)
                {
                    debuffarmorst = 0.75f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[1] == 2)
                {
                    debuffarmorst = 0.5f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[1] == 3)
                {
                    debuffarmorst=0.25f;
                }
                break;
            case "Green":
                if (PlayerStats.instance.pickaxeGemsTier[1] == 1)
                {
                    poisonst = 1;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[1] == 2)
                {
                    poisonst = 1.5f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[1] == 3)
                {
                    poisonst = 2;
                }
                break;
            case "Red":
                if (PlayerStats.instance.pickaxeGemsTier[1] == 1)
                {
                    healmultiplest = .3f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[1] == 2)
                {
                    healmultiplest = .4f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[1] == 3)
                {
                    healmultiplest = .6f;
                }
                break;
                
        }
        switch (equipedGemPower)
        {
            case "Blue":
                if (PlayerStats.instance.pickaxeGemsTier[2] == 1)
                {
                    cuthealst = 1;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[2] == 2)
                {
                    cuthealst = 2;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[2] == 3)
                {
                    cuthealst = 3;
                }
                break;
            case "Green":
                if (PlayerStats.instance.pickaxeGemsTier[2] == 1)
                {
                    buffattackst = 1.25f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[2] == 2)
                {
                    buffattackst = 1.5f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[2] == 3)
                {
                    buffattackst = 1.75f;
                }
                break;
            case "Red":
                if (PlayerStats.instance.pickaxeGemsTier[2] == 1)
                {
                    healpowerst = .3f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[2] == 2)
                {
                    healpowerst = .4f;
                }
                else if (PlayerStats.instance.pickaxeGemsTier[2] == 3)
                {
                    healpowerst = .6f;
                }
                break;
                
        }
        
 }
    public void TakeDamage(float dmg,Unit unit)
    {   
       armor =CheckArmor();
        dmg =CheckDmg(unit,dmg);

        if (unit.debuffHeal <= 0)
        {
            if (unit.Element == "Red")
            {
                unit.currentHP += dmg / 2;
            }
        }
       
        if (shield > 0)
        {
            dmg -= dmg * shield ;
          currentHP =  Damage(dmg,unit);
        }
        else
        { 
           currentHP = Damage(dmg,unit);
        }

        anim.SetBool("dano", true);

        anim.SetBool("dano", false);

    }

   
    
}
