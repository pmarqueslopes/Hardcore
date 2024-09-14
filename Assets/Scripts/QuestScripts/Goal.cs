using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Goal 
{
    [TextArea(2,4)]
    public string description; 
    public bool isComplete;
    public TextMeshProUGUI texto;
    public Transform goalActT;
    public GoalSM goalAct;
    public Transform[] objects;

    public void Init() {
        goalAct = goalActT.GetComponent<GoalSM>();

        goalAct.PrepareGoal(objects);
    }

    public void Gupdate() {
        
        if( goalAct.GoalUpdate(objects) ){
            
            goalAct.QuitGoal(objects);
            isComplete = true;
        }
    }
}