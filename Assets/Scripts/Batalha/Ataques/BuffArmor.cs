using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffArmor : BaseAttack
{
    public  string attackName;
    public float damage;
    public Animator anim;
    public int waitTime = 2;
    public string animName;
    public string particula;
    public ParticleSystem armorPart;
    public override IEnumerator Attack(PlayerUnit player,Unit unit)
    {
        unit.waitTime = waitTime;
      
        BattleSystem.BS.startText.text = unit.unitName + " usou "+ attackName;
        anim.SetBool("idle",false);
        anim.SetBool(animName,true);
        switch (particula)
        {
            case "bite": BattleSystem.BS.bite.Play();
                break;
            case "claw":BattleSystem.BS.claw.Play(); break;
            case "punch":  BattleSystem.BS.punch.Play();
               
                break;
            
        }
        yield return new WaitForSeconds(1f);
        player.TakeDamage(damage,unit);
        unit.buffArmorRounds+= 3;
        unit.buffArmorValue = 1.5f;
        armorPart.Play();
        yield return new WaitForSeconds(1f);
        BattleSystem.BS.playerHUD.SetHP(player.currentHP);
        BattleSystem.BS.playerHUD.SetBuffs(player);
        
       
        anim.SetBool(animName,false);
        anim.SetBool("idle",true);
        
    }
}
