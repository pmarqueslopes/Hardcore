using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string questName;
    public bool complete;

    public int indice;
    
    int indiceGoalMax;
    public List<Goal> goals;

    private void Start() {

        if(goals[indice] != null){
            goals[indice].Init();
        }
        else
        {
            goals[indice].isComplete = true;
        }

    }

    private void Update() {
        
        if(complete){
            return;
        }

        if(goals[indice] != null){

            if(goals[indice].isComplete == true){
                indice ++;
                indice = Mathf.Clamp( indice, 0, goals.Count -1 );
                goals[indice].Init();
                return;
            }

            goals[indice].Gupdate();

        }

        if(CheckAllGoalsComplete()){
            complete = true;
        }

    }

    bool CheckAllGoalsComplete(){

        bool result = false;

        foreach (var g in goals)
        {
            if(g.isComplete){
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

}