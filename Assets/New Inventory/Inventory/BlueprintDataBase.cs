using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintDataBase : MonoBehaviour
{
    public List<Blueprint> blueprints = new List<Blueprint>();
    ItemDataBase dataBase;

    void Start()
    {
        dataBase = GameObject.FindGameObjectWithTag("ItemDataBase").GetComponent<ItemDataBase>();

        //Gemas Tier 2

        blueprints.Add(new Blueprint(new List<int>(new int[] { 5, 5 }), dataBase.items[8]));
        blueprints.Add(new Blueprint(new List<int>(new int[] { 6, 6 }), dataBase.items[9]));
        blueprints.Add(new Blueprint(new List<int>(new int[] { 7, 7 }), dataBase.items[10]));

        //Gemas Tier 3

        blueprints.Add(new Blueprint(new List<int>(new int[] { 8, 8 }), dataBase.items[11]));
        blueprints.Add(new Blueprint(new List<int>(new int[] { 9, 9 }), dataBase.items[12]));
        blueprints.Add(new Blueprint(new List<int>(new int[] { 10, 10 }), dataBase.items[13]));
    }
}
