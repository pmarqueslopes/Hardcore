using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMonster : MonoBehaviour
{
   public void ResetArea()
   {
      for (int i = 0; i < CombatTransition.instance.InimigosAzul.Length; i++)
      {
         CombatTransition.instance.InimigosAzul[i] = false;
      }
      for (int i = 0; i < CombatTransition.instance.InimigosVerde.Length; i++)
      {
         CombatTransition.instance.InimigosVerde[i] = false;
      }
      for (int i = 0; i < CombatTransition.instance.InimigosVermelho.Length; i++)
      {
         CombatTransition.instance.InimigosVermelho[i] = false;
      }
   }
}
