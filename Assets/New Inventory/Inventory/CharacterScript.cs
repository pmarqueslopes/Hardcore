using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            transform.GetChild(i).GetComponent<CharacterSlot>().index = i;   
        }
    }

}
