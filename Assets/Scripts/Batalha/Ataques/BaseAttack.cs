using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    

    public virtual IEnumerator Attack(PlayerUnit player, Unit unit)
    {
        yield break;
    }

    
}
