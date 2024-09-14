using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] waypoints;
    [SerializeField] private int index;
    public GameObject Player;
    [SerializeField]private float distance;
    public float maxDistance;
    private Vector3 playerTransform;
    [SerializeField] private bool chase;
    private EnemyAI ai;
    public Animator anim;
    public Chase chaseScript;
    
    void Start()
    {
        ai = this;
        anim = GetComponentInChildren<Animator>();
        StartCoroutine(CheckDistance());
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        index = 0;
        chase = false;
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (chase == false)
        {
            if(other.CompareTag("Waypoint"))
            {
                index++;
            }
            if (index >= waypoints.Length)
            {
                index = 0;
            }
            Patrol();
        }
        
        
    }

    void Patrol()
    {
       
        agent.SetDestination(waypoints[index].position);
        anim.SetBool("idle",false);
        anim.SetBool("walk",true);
    }

   void  Chase()
    {  
        chase = true;
        anim.SetBool("idle",false);
        anim.SetBool("walk",true);
        chaseScript.enabled = true;
        agent.enabled = false;
        this.enabled = false;
        

    }

    IEnumerator CheckDistance()
    {   
        distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance > maxDistance)
        {
            Patrol();
           
           
        }
        else
        {   anim.SetBool("walk",false);
            anim.SetBool("idle",true);
            
            agent.speed = 0;
            yield return new WaitForSeconds(1);
            distance = Vector3.Distance(transform.position, Player.transform.position);
            if (distance <= maxDistance)
            {
                Chase();
                StopCoroutine(CheckDistance());
            }
        }
        
        yield return new WaitForSeconds(0.5f);
        if (chase == false)
        {
            StartCoroutine(CheckDistance()); 
        }
        
    }


    private void Update()
    {
        playerTransform = Player.transform.position;
    }
}
