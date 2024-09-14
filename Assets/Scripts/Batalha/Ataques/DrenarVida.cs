using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrenarVida : BaseAttack
{
    public  string attackName;
    public float damage;
    public Animator anim;
    public int waitTime = 2;
    public string animName;
    public string particula;
    public ParticleSystem heal;
    public override IEnumerator Attack(PlayerUnit player,Unit unit)
    {
        unit.waitTime = waitTime;
      
        BattleSystem.BS.startText.text = unit.unitName + " usou "+ attackName;
        anim.SetBool("idle",false);
        anim.SetBool(animName,true);
        yield return new WaitForSeconds(1f);
        player.TakeDamage(damage,unit);
        if (unit.debuffHeal > 0)
        {
            unit.currentHP += damage / 4;
        }
        else
        {
            unit.currentHP += damage / 2;
        }
        if (unit.currentHP >= unit.maxHP)
        {
            unit.currentHP = unit.maxHP;
        }

        heal.Play();
        switch (particula)
        {
            case "bite": BattleSystem.BS.bite.Play();
                break;
            case "claw":BattleSystem.BS.claw.Play(); break;
            case "punch":  BattleSystem.BS.punch.Play();
                break;
            
            
        }
        yield return new WaitForSeconds(1f);
        BattleSystem.BS.playerHUD.SetHP(player.currentHP);
        BattleSystem.BS.playerHUD.SetBuffs(player);
        
        anim.SetBool(animName,false);
        anim.SetBool("idle",true);
        
    }
}
