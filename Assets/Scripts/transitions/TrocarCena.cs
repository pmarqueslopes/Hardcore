using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{   
    public int enemyNumber1;
    public int enemyNumber2;
    public int currentEnemy;
    public BoxCollider collider;
    public int enemyXp;
    public bool boss;
    public string nomeDaCena;

    IEnumerator colliderStart()
    {
        yield return new WaitForSeconds(3);
        collider.enabled = true;
        
    }

    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
    }

    private void Start()
    {   
        collider.enabled = false;
        StartCoroutine(colliderStart());

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            CombatTransition.instance.scene = SceneManager.GetActiveScene().name;
            TipoInimigo.TI.tipoInimigo1 = enemyNumber1;
            TipoInimigo.TI.tipoInimigo2 = enemyNumber2;
            TipoInimigo.TI.bossBool = boss;
            CombatTransition.instance.currentenemy = currentEnemy;
            CombatTransition.instance.playerPosition = this.gameObject.transform.position;
            CombatTransition.instance.xpValue = enemyXp;
            SceneManager.LoadScene(nomeDaCena);
            
            
            
            Destroy(this.gameObject);

            quest4.batalha++;
            
            if(SceneManager.GetActiveScene().name == "AreaVermelha" && boss == true)
            {
                quest6.batalhaboss++;
            }
            if(SceneManager.GetActiveScene().name == "AreaAzul")
            {
                quest9.batalhaA++;
            }
            if (SceneManager.GetActiveScene().name == "AreaAzul" && boss == true)
            {
                quest11.batalhabossA++;
            }
            if (SceneManager.GetActiveScene().name == "AreaVerde")
            {
                quest14.batalhaV++;
            }
            if (SceneManager.GetActiveScene().name == "AreaVerde" && boss == true)
            {
                quest16.batalhabossVerde++;
            }

        }
    }

    
}