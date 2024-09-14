using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSystem : MonoBehaviour
{
    List<CraftSlot> slots = new List<CraftSlot>();

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            slots.Add(transform.GetChild(i).GetComponent<CraftSlot>());
        }
    }

    void Update()
    {
        
    }
}
