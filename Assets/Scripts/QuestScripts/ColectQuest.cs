using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColectQuest : MonoBehaviour ,GoalSM
{   

    public void PrepareGoal(Transform[] objs){

        foreach (var o in objs)
        {
            o.gameObject.SetActive(true);
        }
    }

    public bool GoalUpdate(Transform[] objs){
        bool result = false;

        foreach (var o in objs)
        {
            
            if(o == null){
                result = true;
            }
            else
            {
                result = false;
                break;
            }
        }
        
        return result;

    }

    public void QuitGoal(Transform[] objs){

    }
}