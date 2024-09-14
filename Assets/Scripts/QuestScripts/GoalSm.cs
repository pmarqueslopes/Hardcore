using UnityEngine;

public interface GoalSM 
{
    
    void PrepareGoal(Transform[] objs);

    bool GoalUpdate(Transform[] objs);

    void QuitGoal(Transform[] objs);

}