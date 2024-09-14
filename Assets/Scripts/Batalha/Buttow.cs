using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttow : MonoBehaviour
{
    public int id;

    private void OnMouseDown()
    {   
        switch (id)
        {
            case 0: BattleSystem.BS.AttackEnemy1(); break;
            case 1: BattleSystem.BS.AttackEnemy2(); break;
            case 2: BattleSystem.BS.AttackEnemy1Power(); break;
            case 3: BattleSystem.BS.AttackEnemy2Power(); break;
        }
    }
}
