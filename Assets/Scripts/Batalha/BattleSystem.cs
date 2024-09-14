using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.VFX;


public class BattleSystem : MonoBehaviour
{
    public static BattleSystem BS { get; private set;}
    private void Awake()
    {   if (BS != null && BS!= this)
        {
            Destroy(gameObject);
        }
        else
        {
            BS = this;
        }

        boss = TipoInimigo.TI.bossBool;
        SetupBattle();
    }
    
    public enum BattleState
    {
        START,
        PLAYERTURN,
        ENEMYTURN,
        SELECTATTACK,
        WON,
        LOST
    }

    public int aliveEnemies =2;
    public int target=0;

    
   
   
    public ParticleSystem punch;
    public VisualEffect bite;
    public ParticleSystem claw;
   
    public Animator playerAnim;
    public Animator enemyAnim1;
    public Animator enemyAnim2;

    public GameObject playerPrefab;
    public GameObject[] enemyPrefabs;

    public Transform playerBattleStation;
    public Transform EnemyBattleStation1;
    public Transform EnemyBattleStation2;
    public Transform BossBattleStation;

    

    private PlayerUnit playerUnit;
    private Unit enemyUnit1;
    private Unit enemyUnit2;

    public Text startText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD1;
    public BattleHUD enemyHUD2;
    

    public BattleState state;
    public GameObject dialogBT;
    public GameObject singleBT;
    public GameObject multipleBT;
    public GameObject powerBT;
    public GameObject ultBT;
    public GameObject shieldBT;
    public GameObject btTarget1;
    public GameObject btTarget2;
    public GameObject btTargetPower1;
    public GameObject btTargetPower2;
    public GameObject returnBT;
    public GameObject bagBT;
    public GameObject healthBT;
    public GameObject furyBT;
    public Slider furySlider;

    public GameObject[] areas;

    public BattleCamera battleCam;
    public bool boss;

    public ParticleSystem heal;
    private Color bluegem = new Color(9f / 255f, 132f / 255f, 227f / 255f, 1f);
    private Color greengem = new Color(0f,184f/255f,94f/255f,1f);
    private Color redgem = new Color(214f/255,48f/255f,49f/255f,1f);

    
    public void SetFury()
    { 
        if (playerUnit.fury >= 100)
        {
                 playerUnit.fury = 100;
        }
        furySlider.value = playerUnit.fury;
       
    }

    void BattleScene()
    {
        switch (CombatTransition.instance.scene)
        {
            case "AreaAzul": Instantiate(areas[0].transform);
                break;
            case "AreaVerde": Instantiate(areas[1].transform);;
                break;
            case "AreaVermelha": Instantiate(areas[2].transform);
                break;
               
        }
    }

    void Start()
    {
        state = BattleState.PLAYERTURN;
        BattleScene();
        StartCoroutine(PlayerTurn());
    }

    void setButtonColors()
    {
        switch (playerUnit.equipedGemSingle)
        {
           case "Blue": singleBT.GetComponent<Image>().color = bluegem;
               break;
           case "Green": singleBT.GetComponent<Image>().color = greengem;
            
               break;
           case "Red": singleBT.GetComponent<Image>().color = redgem;
             
               break;
           default: singleBT.GetComponent<Image>().color = Color.white;
               break;
        }
        switch (playerUnit.equipedGemMultiple)
        {
            case "Blue": multipleBT.GetComponent<Image>().color = bluegem;
              
                break;
            case "Green": multipleBT.GetComponent<Image>().color = greengem;
              
                break;
            case "Red": multipleBT.GetComponent<Image>().color = redgem;
              
                break;
            default: multipleBT.GetComponent<Image>().color = Color.white;
               
                break;
        }
        switch (playerUnit.equipedGemPower)
        {
            case "Blue": powerBT.GetComponent<Image>().color = bluegem;
               
                break;
            case "Green": powerBT.GetComponent<Image>().color = greengem;
               
                break;
            case "Red": powerBT.GetComponent<Image>().color = redgem;
               
                break;
            default: powerBT.GetComponent<Image>().color = Color.white;
                
                break;
        }
        
    }

    

    void SetEnemyHuds()
    {
        enemyHUD1.SetHP(enemyUnit1.currentHP);
        enemyHUD1.SetEnemyDebuffs(enemyUnit1);
        if (boss == false)
        {
            enemyHUD2.SetHP(enemyUnit2.currentHP);
            enemyHUD2.SetEnemyDebuffs(enemyUnit2);
        }
        
    }
    
    void SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation.transform);
        playerUnit = playerGO.GetComponent<PlayerUnit>();
        playerAnim = playerGO.GetComponentInChildren<Animator>();
        if (boss == false)
        {   
            GameObject enemyGo1 = Instantiate(enemyPrefabs[TipoInimigo.TI.tipoInimigo1], EnemyBattleStation1.transform.position,Quaternion.identity);
            enemyUnit1 = enemyGo1.GetComponent<Unit>();
            enemyAnim1 = enemyGo1.GetComponentInChildren<Animator>();
            GameObject enemyGo2 = Instantiate(enemyPrefabs[TipoInimigo.TI.tipoInimigo2], EnemyBattleStation2.transform.position,Quaternion.identity);
            enemyUnit2 = enemyGo2.GetComponent<Unit>();
            enemyAnim2 = enemyGo2.GetComponentInChildren<Animator>();
            enemyUnit1.transform.LookAt(playerUnit.transform);
            enemyUnit2.transform.LookAt(playerUnit.transform);
            startText.text = "Um " + enemyUnit1.unitName +" e "+ enemyUnit2.unitName +" estão te atacando";
        }
        else
        {
            GameObject enemyGo1 = Instantiate(enemyPrefabs[TipoInimigo.TI.tipoInimigo1],BossBattleStation.transform.position,Quaternion.identity);
            enemyUnit1 = enemyGo1.GetComponent<Unit>();
            enemyAnim1 = enemyGo1.GetComponentInChildren<Animator>();
            GameObject enemyGo2 = Instantiate(enemyPrefabs[12], EnemyBattleStation2.transform.position,Quaternion.identity);
            enemyUnit2 = enemyGo2.GetComponent<Unit>();
            enemyUnit1.transform.LookAt(playerUnit.transform);
            enemyUnit2.isAlive = false;
            aliveEnemies--;
            enemyHUD2.BossDeactivate();

            btTarget1.transform.position = new Vector3(btTarget1.transform.position.x+5, btTarget1.transform.position.y, btTarget1.transform.position.z);
          
            startText.text = "Um " + enemyUnit1.unitName  +" está te atacando";

        }
        
        playerUnit.LoadStats();
        

        playerHUD.SetPlayerHUD(playerUnit);
        enemyHUD1.SetEnemyHUD(enemyUnit1);
        if(boss==false)enemyHUD2.SetEnemyHUD(enemyUnit2);
       
        SetFury();
        
        
        
        setButtonColors();
        

        state = BattleState.PLAYERTURN;

        
    }
 IEnumerator PlayerTurn()
 {   if (aliveEnemies<=0)
     {
         state = BattleState.WON;
         EndBattle();
         yield break;
     }
     SetEnemyHuds();
     battleCam.ChooseAction();
     if (playerUnit.poisonRounds > 0)
     {   playerHUD.SetBuffs(playerUnit);
         startText.text = playerUnit.unitName + " está envenenado";
         yield return new WaitForSeconds(1f);
         playerUnit.Poison();
         playerHUD.SetHP(playerUnit.currentHP);
         playerHUD.SetBuffs(playerUnit);
     }
     CheckAlive();
     playerHUD.SetHP(playerUnit.currentHP);
     playerHUD.SetBuffs(playerUnit);
     
     dialogBT.SetActive(true);
     playerUnit.fury += 15;
     SetFury();
     playerUnit.EndTurn();
        playerUnit.shield = 0;
        startText.text = "  Escolha uma ação: ";
        if (playerUnit.fury >= playerUnit.singleCost)
        {
            singleBT.SetActive(true);
        }

        if (playerUnit.fury >= playerUnit.multipleCost)
        {
            multipleBT.SetActive(true);
        }

        if (playerUnit.fury >= playerUnit.powerSingleCost)
        {
            powerBT.SetActive(true);
        }
        if (playerUnit.fury >= playerUnit.ultimateCost)
        {
            ultBT.SetActive(true);
        }
       
       
        shieldBT.SetActive(true);
        bagBT.SetActive(true);
     
        
    }

 
   IEnumerator SingleAttack()
    {   state = BattleState.PLAYERTURN;
        returnBT.SetActive(false);
        playerUnit.fury -= playerUnit.singleCost;
        SetFury();
        battleCam.PlayerAttack();
        if (target == 1)
        {
                    enemyUnit1.TakeDamageSingle(playerUnit.damageSingle,playerUnit.equipedGemSingle,playerUnit);
                    startText.text = playerUnit.unitName + " Está atacando";
                    playerAnim.SetBool("single", true);
                    playerAnim.SetBool("idle", false);
                    DeActivateBt();
                    yield return new WaitForSeconds(1f);

                    startText.text = " Acertou o ataque";
                    

                    yield return new WaitForSeconds(1);
                    
                    enemyHUD1.SetHP(enemyUnit1.currentHP);
                    enemyHUD1.SetEnemyDebuffs(enemyUnit1);
                    
                    yield return new WaitForSeconds(.5f);
                    playerHUD.SetHP(playerUnit.currentHP);
                    playerHUD.SetBuffs(playerUnit);
                    playerAnim.SetBool("idle", true);
                    playerAnim.SetBool("single",false);
                    

                    if (aliveEnemies<=0)
                    {
                        state = BattleState.WON;
                        EndBattle();
                    }
                    else
                    {
                        state = BattleState.ENEMYTURN;
                        StartCoroutine(Enemy1Turn());
                    }
        }
        else if (target == 2)
        {
            enemyUnit2.TakeDamageSingle(playerUnit.damageSingle,playerUnit.equipedGemSingle,playerUnit);
            startText.text = playerUnit.unitName + " está atacando";
            playerAnim.SetBool("single", true);
            playerAnim.SetBool("idle", false);
            DeActivateBt();
            yield return new WaitForSeconds(1f);
            startText.text = "Acertou o ataque";
            yield return new WaitForSeconds(1);
            
            enemyHUD2.SetHP(enemyUnit2.currentHP);
            enemyHUD2.SetEnemyDebuffs(enemyUnit2);
            yield return new WaitForSeconds(.5f);
            playerHUD.SetHP(playerUnit.currentHP);
            playerHUD.SetBuffs(playerUnit);
            playerAnim.SetBool("idle", true);
            playerAnim.SetBool("single",false);
            if (aliveEnemies<=0)
            {
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(Enemy1Turn());
            }
        }

        target = 0;


    } 
    IEnumerator MultipleAttack()
         {
             state = BattleState.PLAYERTURN;
             playerUnit.fury -= playerUnit.multipleCost;
             SetFury();
             battleCam.PlayerAttack();
             enemyUnit1.TakeDamageMultiple(playerUnit.damageMultiple,playerUnit.equipedGemMultiple,playerUnit);
             enemyUnit2 .TakeDamageMultiple(playerUnit.damageMultiple,playerUnit.equipedGemMultiple,playerUnit);
             startText.text = playerUnit.unitName + " atacou" + enemyUnit1.unitName + " e " + enemyUnit2.unitName;
             playerAnim.SetBool("multiple", true);
             playerAnim.SetBool("idle", false);
             DeActivateBt();
             yield return new WaitForSeconds(1.5f);
     
             startText.text = "Acertou os ataques";
     
             yield return new WaitForSeconds(1);
             playerAnim.SetBool("idle", true);
             playerAnim.SetBool("multiple",false);
             enemyHUD1.SetHP(enemyUnit1.currentHP);
             enemyHUD1.SetEnemyDebuffs(enemyUnit1);
             if(boss==false)
             { enemyHUD2.SetHP(enemyUnit2.currentHP);
                 enemyHUD2.SetEnemyDebuffs(enemyUnit2);
             }
             yield return new WaitForSeconds(.5f);
             playerHUD.SetHP(playerUnit.currentHP);
             playerHUD.SetBuffs(playerUnit);
             if (aliveEnemies<=0)
             {
                 state = BattleState.WON;
                 EndBattle();
             }
             else
             {
                 state = BattleState.ENEMYTURN;
                 StartCoroutine(Enemy1Turn());
             }
         }
    IEnumerator PowerAttack()
    {   state = BattleState.PLAYERTURN;
        returnBT.SetActive(false);
        playerUnit.fury -= playerUnit.powerSingleCost;
        SetFury();
        battleCam.PlayerAttack();
        if (target == 1)
        {  DeActivateBt();
            //INSTANCE 1
            enemyUnit1.TakeDamagePower(playerUnit.damagePower,playerUnit.equipedGemPower,playerUnit);
            startText.text = playerUnit.unitName + " primeiro ataque ";
            playerAnim.SetBool("power", true);
            playerAnim.SetBool("idle", false);
            
            yield return new WaitForSeconds(1f);
            enemyHUD1.SetHP(enemyUnit1.currentHP);
            enemyHUD1.SetEnemyDebuffs(enemyUnit1);
            playerAnim.SetBool("power", false);
            playerAnim.SetBool("idle", true);
            yield return new WaitForSeconds(.5f);
            playerHUD.SetHP(playerUnit.currentHP);
            playerHUD.SetBuffs(playerUnit);
            
            yield return new WaitForSeconds(1f);
            //INSTANCE 2
            enemyUnit1.TakeDamagePower(playerUnit.damagePower,playerUnit.equipedGemPower,playerUnit);
            startText.text = playerUnit.unitName + " segundo ataque";
            playerAnim.SetBool("power", true);
            playerAnim.SetBool("idle", false);
            
            yield return new WaitForSeconds(1f);
            enemyHUD1.SetHP(enemyUnit1.currentHP);
            enemyHUD1.SetEnemyDebuffs(enemyUnit1);
            yield return new WaitForSeconds(.5f);
            playerHUD.SetHP(playerUnit.currentHP);
            playerHUD.SetBuffs(playerUnit);
            playerAnim.SetBool("power", false);
            playerAnim.SetBool("idle", true);
            yield return new WaitForSeconds(1f);
            //INSTANCE 3
            enemyUnit1.TakeDamagePower(playerUnit.damagePower,playerUnit.equipedGemPower,playerUnit);
            startText.text = playerUnit.unitName + " terceiro ataque";
            playerAnim.SetBool("power", true);
            playerAnim.SetBool("idle", false);
            
            yield return new WaitForSeconds(2f);
            playerAnim.SetBool("power", false);
            playerAnim.SetBool("idle", true);
            enemyHUD1.SetHP(enemyUnit1.currentHP);
            enemyHUD1.SetEnemyDebuffs(enemyUnit1);
            yield return new WaitForSeconds(.5f);
            playerHUD.SetHP(playerUnit.currentHP);
            playerHUD.SetBuffs(playerUnit);
            

            yield return new WaitForSeconds(1);
            

            if (aliveEnemies<=0)
            {
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(Enemy1Turn());
            }
        }
        else if (target == 2)
        {  DeActivateBt();
            //INSTANCE 1
            enemyUnit2.TakeDamagePower(playerUnit.damagePower,playerUnit.equipedGemPower,playerUnit);
            startText.text = playerUnit.unitName + " primeiro ataque";
            playerAnim.SetBool("power", true);
            playerAnim.SetBool("idle", false);
            
            yield return new WaitForSeconds(1f);
            enemyHUD2.SetHP(enemyUnit2.currentHP);
            enemyHUD2.SetEnemyDebuffs(enemyUnit2);
            yield return new WaitForSeconds(.5f);
            playerHUD.SetHP(playerUnit.currentHP);
            playerHUD.SetBuffs(playerUnit);
            playerAnim.SetBool("power", false);
            playerAnim.SetBool("idle", true);
            yield return new WaitForSeconds(1f);
            //INSTANCE 2
            enemyUnit2.TakeDamagePower(playerUnit.damagePower,playerUnit.equipedGemPower,playerUnit);
            startText.text = playerUnit.unitName + " segundo ataque";
            playerAnim.SetBool("power", true);
            playerAnim.SetBool("idle", false);
            
            yield return new WaitForSeconds(1f);
            enemyHUD2.SetHP(enemyUnit2.currentHP);
            enemyHUD2.SetEnemyDebuffs(enemyUnit2);
            yield return new WaitForSeconds(.5f);
            playerHUD.SetHP(playerUnit.currentHP);
            playerHUD.SetBuffs(playerUnit);
            playerAnim.SetBool("power", false);
            playerAnim.SetBool("idle", true);
            yield return new WaitForSeconds(1f);
            //INSTANCE 3
            enemyUnit2.TakeDamagePower(playerUnit.damagePower,playerUnit.equipedGemPower,playerUnit);
            startText.text = playerUnit.unitName + " terceiro ataque";
            playerAnim.SetBool("power", true);
            playerAnim.SetBool("idle", false);
            
            yield return new WaitForSeconds(1f);
            enemyHUD2.SetHP(enemyUnit2.currentHP);
            enemyHUD2.SetEnemyDebuffs(enemyUnit2);
            yield return new WaitForSeconds(.5f);
            playerHUD.SetHP(playerUnit.currentHP);
            playerHUD.SetBuffs(playerUnit);
            
            playerAnim.SetBool("power", false);
            playerAnim.SetBool("idle", true);

            yield return new WaitForSeconds(1f);
            

            if (aliveEnemies<=0)
            {
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(Enemy1Turn());
            }
        }

        target = 0;


    }
    IEnumerator Ultimate()
    {
        state = BattleState.PLAYERTURN;
        float totalDamage = playerUnit.damageUlt * (1.0f + (playerUnit.fury / 100));
        playerUnit.fury = 0;
        SetFury();
        battleCam.PlayerAttack();
        yield return new WaitForSeconds(1);
       
        enemyUnit1.TakeDamageUlt(totalDamage,playerUnit);
        if(boss==false)
        {
            enemyUnit2.TakeDamageUlt(totalDamage,playerUnit);
            startText.text = playerUnit.unitName + " Usou a ultimate no " + enemyUnit1.unitName + " e no " + enemyUnit2.unitName;
        }
        else
        {
            startText.text = playerUnit.unitName + " Usou a ultimate no " + enemyUnit1.unitName;
        }
      
        
        playerAnim.SetBool("ult", true);
        playerAnim.SetBool("idle", false);
        DeActivateBt();
        yield return new WaitForSeconds(3f);
        startText.text = "Ataque bem sucedido";
        yield return new WaitForSeconds(1);
        playerAnim.SetBool("ult", false);
        playerAnim.SetBool("idle", true);
        enemyHUD1.SetHP(enemyUnit1.currentHP);
        enemyHUD1.SetEnemyDebuffs(enemyUnit1);
        if(boss==false)
        { enemyHUD2.SetHP(enemyUnit2.currentHP);
            enemyHUD2.SetEnemyDebuffs(enemyUnit2);
        }
        yield return new WaitForSeconds(.5f);
        playerHUD.SetHP(playerUnit.currentHP);
        playerHUD.SetBuffs(playerUnit);

        if (aliveEnemies<=0)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(Enemy1Turn());
        }
    }
   
    void DeActivateBt()
    {
        singleBT.SetActive(false);
        multipleBT.SetActive(false);
        shieldBT.SetActive(false);
        powerBT.SetActive(false);
        ultBT.SetActive(false);
        btTarget1.SetActive(false);
        btTarget2.SetActive(false);
        btTargetPower1.SetActive(false);
        btTargetPower2.SetActive(false);
        returnBT.SetActive(false);
        bagBT.SetActive(false);
        furyBT.SetActive(false);
        healthBT.SetActive(false);
        
        
    }


    void CheckAlive()
    {
        if (playerUnit.currentHP <= 0)
        {
            state = BattleState.LOST;
            playerUnit.fury = 0;
            
            EndBattle();
        }
    }

   
    public void  SelectTarget(int n) //Chamar no BT attack1
    {
        DeActivateBt();
        returnBT.SetActive(true);
       
        battleCam.ChooseTarget();
        
        
        startText.text = "Choose a target";
        if (enemyUnit1.isAlive == true)
        {   switch(n)

            {
                case 1: 
                    btTarget1.SetActive(true); 
                    break;
                case 2: 
                    btTargetPower1.SetActive(true); 
                    break;
            }
           
        }
        if (enemyUnit2.isAlive == true)
        {    switch(n)

            {
                case 1: 
                    btTarget2.SetActive(true); 
                    break;
                case 2: 
                    btTargetPower2.SetActive(true); 
                    break;
            }
            
        }
        
        

    }
    public void ReturnBT()
    {
        state = BattleState.PLAYERTURN;
        battleCam.ChooseAction();
        btTarget1.SetActive(false);
        btTarget2.SetActive(false);
        btTargetPower1.SetActive(false);
        btTargetPower2.SetActive(false);
        returnBT.SetActive(false);
        
        if (playerUnit.fury >= playerUnit.singleCost)
        {
            singleBT.SetActive(true);
        }

        if (playerUnit.fury >= playerUnit.multipleCost)
        {
            multipleBT.SetActive(true);
        }

        if (playerUnit.fury >= playerUnit.powerSingleCost)
        {
            powerBT.SetActive(true);
        }
        if (playerUnit.fury >= playerUnit.ultimateCost)
        {
            ultBT.SetActive(true);
        }

       furyBT.SetActive(false);
       healthBT.SetActive(false);
       
        shieldBT.SetActive(true);
        bagBT.SetActive(true);
        
        
    }

    public void AttackEnemy1()
    {
        target = 1;
        dialogBT.SetActive(false);
        StartCoroutine(SingleAttack());
        
    }
    public void AttackEnemy2()
    {
        target = 2;
        dialogBT.SetActive(false);
        StartCoroutine(SingleAttack());
    }
    public void AttackEnemy1Power()
    {
        target = 1;
        dialogBT.SetActive(false);
        StartCoroutine(PowerAttack());
    }
    public void AttackEnemy2Power()
    {
        target = 2;
        dialogBT.SetActive(false);
        StartCoroutine(PowerAttack());
    }

    IEnumerator Enemy1Turn()
    { //turno inimigo 1
        if (aliveEnemies<=0)
        {
            state = BattleState.WON;
            EndBattle();
        }
        
        if (enemyUnit1.isAlive == true)
        {   enemyUnit1.EndTurn();
            SetEnemyHuds();
            
            if (enemyUnit1.poisonRounds > 0)
            {   enemyHUD1.SetEnemyDebuffs(enemyUnit1);
                enemyUnit1.Poison(playerUnit);
                startText.text = enemyUnit1.unitName + " está envenenado";
                yield return new WaitForSeconds(1f);
                enemyHUD1.SetHP(enemyUnit1.currentHP);
                enemyHUD1.SetEnemyDebuffs(enemyUnit1);

                yield return new WaitForSeconds(1f);

            }

            if (enemyUnit1.isAlive == true)
            {   battleCam.Enemy1Attack();
                enemyUnit1.Attack(playerUnit, enemyUnit1);
                yield return new WaitForSeconds(enemyUnit1.waitTime);
                enemyHUD1.SetHP(enemyUnit1.currentHP);
                enemyHUD1.SetEnemyDebuffs(enemyUnit1);
                if (playerUnit.currentHP<=0)
                {
                    state = BattleState.LOST;
                    EndBattle();
                }
                yield return new WaitForSeconds(.5f);
                enemyHUD1.SetHP(enemyUnit1.currentHP);
                enemyHUD1.SetEnemyDebuffs(enemyUnit1);
                StartCoroutine(Enemy2Turn());
                
            }
            else
            {
                yield return new WaitForSeconds(.5f);

                StartCoroutine(Enemy2Turn());
            }
            
                   
        }
        else
        {
            yield return new WaitForSeconds(.5f);

            StartCoroutine(Enemy2Turn());
        }
        

    }

    IEnumerator Enemy2Turn()
    { if (aliveEnemies<=0)
        {
            state = BattleState.WON;
            EndBattle();
        }
        // turno inimigo 2
        if (enemyUnit2.isAlive == true)
        {
            enemyUnit2.EndTurn();
            SetEnemyHuds();
            
            if (enemyUnit2.poisonRounds > 0)
            {   enemyHUD2.SetEnemyDebuffs(enemyUnit2);
                enemyUnit2.Poison(playerUnit);
                startText.text = enemyUnit2.unitName + " está envenenado";
                yield return new WaitForSeconds(1f);
                enemyHUD2.SetHP(enemyUnit2.currentHP);
                enemyHUD2.SetEnemyDebuffs(enemyUnit2);
                yield return new WaitForSeconds(1f);
                

            }

            if (enemyUnit2.isAlive == true)
            {   battleCam.Enemy2Attack();
    
                enemyUnit2.Attack(playerUnit, enemyUnit2);
                yield return new WaitForSeconds(enemyUnit2.waitTime);
                enemyHUD2.SetHP(enemyUnit2.currentHP);
                enemyHUD2.SetEnemyDebuffs(enemyUnit2);
                if (playerUnit.currentHP<=0)
                {
                    state = BattleState.LOST;
                    EndBattle();
                }
                state = BattleState.PLAYERTURN;
                StartCoroutine(PlayerTurn());
                
            }
            else
            {
                state = BattleState.PLAYERTURN;
                StartCoroutine(PlayerTurn());
            }
            
                   
        }
        else
        {
            state = BattleState.PLAYERTURN;
            StartCoroutine(PlayerTurn());
        }
        
    }

    void EndBattle()
    {   StopAllCoroutines();
        singleBT.SetActive(false);
        multipleBT.SetActive(false);
        shieldBT.SetActive(false);
        powerBT.SetActive(false);
        ultBT.SetActive(false);
        if (state == BattleState.WON)
        {
            WinBattle();
        }
        else if (state == BattleState.LOST)
        {
            LoseBattle();
        }

       
    }

    public void WinBattle()
    {
        state = BattleState.WON;
        startText.text = "Você venceu";
        playerAnim.SetBool("win",true);
        DeActivateBt();
        CombatTransition.instance.DefeatEnemies();
        CombatTransition.instance.BattleWin = true;
        XPmanager.Instance.AddXP(CombatTransition.instance.xpValue);
        XPmanager.Instance.drop = true;
        StartCoroutine(ChangeScene());
        
    }

    public void LoseBattle()
    {
        state = BattleState.LOST;
        startText.text = "Você foi derrotado";
        playerAnim.SetBool("death",true);
        DeActivateBt();
        CombatTransition.instance.BattleWin = false;
        StartCoroutine(ChangeToHub());
    }

    IEnumerator FuryPotion()
    {   DeActivateBt();
        InventoryStats.instance.items[10]--;
        playerUnit.fury += 50;
        SetFury();
        yield return new WaitForSeconds(1f);
        playerHUD.SetHP(playerUnit.currentHP);
        playerHUD.SetBuffs(playerUnit);
        if (aliveEnemies<=0)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(Enemy1Turn());
        }
        
    }
    IEnumerator HealthPotion()
    {   DeActivateBt();
        InventoryStats.instance.items[9]--;
        playerUnit.currentHP += 75;
        if (playerUnit.currentHP >= playerUnit.maxHP)
        {
            playerUnit.currentHP = playerUnit.maxHP;
        }
        yield return new WaitForSeconds(1f);
        playerHUD.SetHP(playerUnit.currentHP);
        playerHUD.SetBuffs(playerUnit);
        if (aliveEnemies<=0)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(Enemy1Turn());
        }
        
    }

    public void HealthButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        DeActivateBt();
        StartCoroutine(HealthPotion());
    }
    public void FuryButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        DeActivateBt();
        StartCoroutine(FuryPotion());
    }
    
    public void Attack1Button()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;

        }

        state = BattleState.SELECTATTACK;
        
        SelectTarget(1);

    }
    public void PowerAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;

        }

        state = BattleState.SELECTATTACK;
        
        SelectTarget(2);

    }

    public void UltimateButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;

        }

        StartCoroutine(Ultimate());
        quest5.ultimateUse++;
        quest10.ultimateUses++;
    }

    public void BagButton()
    {   DeActivateBt();
        
        returnBT.SetActive(true);
        if (InventoryStats.instance.items[9] > 0)
        {
            healthBT.SetActive(true);
            
        }
        else
        {
            healthBT.SetActive(false);
            
        }
        if (InventoryStats.instance.items[10] > 0)
        {
            furyBT.SetActive(true);
            
            
        }
        else
        {
            furyBT.SetActive(false);
          
        }
    }

    public void MultipleAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;

        }
        
        StartCoroutine(MultipleAttack());
    }
    

    public void Shield()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
       DeActivateBt();
        playerUnit.shield = 0.25f;
        StartCoroutine(Enemy1Turn());

    }

    IEnumerator ChangeScene()
    {   
        CombatTransition.instance.DefeatEnemies();
        
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(CombatTransition.instance.scene);
        
    }
    
    IEnumerator ChangeToHub()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("World");
    }
    
  
}



