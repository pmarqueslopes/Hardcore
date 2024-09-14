using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class BattleCamera : MonoBehaviour
{
   private Cinemachine.CinemachineDollyCart cart;
   public Cinemachine.CinemachineVirtualCamera camera;

   public Cinemachine.CinemachineSmoothPath startPath;
   public Cinemachine.CinemachineSmoothPath[] tracks;
   public GameObject[] focus;
   
   

   private void Awake()
   {
       cart = GetComponent<Cinemachine.CinemachineDollyCart>();
       Reset();
   }

 public void Reset()
   {
       StopAllCoroutines();
       cart.m_Path = startPath;
       
   }
 public void ChooseAction()
 {
     cart.m_Path = tracks[0];
     camera.LookAt = focus[0].transform;
     cart.m_Speed = 1.5f;
     cart.m_Position = 0;
 }

 public void ChooseTarget()
 {
     cart.m_Path = tracks[1];
     camera.LookAt = focus[1].transform;
     cart.m_Speed = 4f;
     cart.m_Position = 0;
 }
 

 public void Enemy1Attack()
 {
     cart.m_Path = tracks[2];
     camera.LookAt = focus[2].transform;
     cart.m_Speed = 4f;
     cart.m_Position = 0;
     
 }
 public void Enemy2Attack()
 {
     cart.m_Path = tracks[3];
     camera.LookAt = focus[3].transform;
     cart.m_Speed = 4f;
     cart.m_Position = 0;
    
 }

 public void PlayerAttack()
 {
     cart.m_Path = tracks[4];
     camera.LookAt = focus[4].transform;
     cart.m_Speed = 4f;
     cart.m_Position = 0;
 }
  
}
