using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VermelhoStart : MonoBehaviour
{
    public GameObject player;
    public GameObject[] inimigosVermelho;
    public Transform spawn;
    public GameObject[] items;

   
    public GameObject dropTransform;

    void CheckDrop()
    {
        if (XPmanager.Instance.drop==true)
        {
            Drop();
        }
    }

    void Drop()
    {
        
        Instantiate(items[CombatTransition.instance.currentenemy], dropTransform.transform);
        XPmanager.Instance.drop = false;
    }
    private void Awake()
    {
        if (CombatTransition.instance.playerPosition !=new Vector3(0,0,0))
        {
            player.transform.position = CombatTransition.instance.playerPosition;
        }
        else
        {
            player.transform.position = spawn.position;
        }
    }

    private void Start()
    {
        ActivateEnemies();
        CombatTransition.instance.playerPosition = new Vector3(0,0,0);
        Debug.Log("Spawn Point " + CombatTransition.instance.playerPosition);
        dropTransform.transform.position = new Vector3(player.transform.position.x + 3, player.transform.position.y + 2,
            player.transform.position.z+2);
        
        CheckDrop();
      
    }

    private void ActivateEnemies()
    {
        for (int i = 0; i < CombatTransition.instance.InimigosVermelho.Length; i++)
        {
            if (CombatTransition.instance.InimigosVermelho[i] == true)
            {
                inimigosVermelho[i].SetActive(false);
            }
        }
    }


}