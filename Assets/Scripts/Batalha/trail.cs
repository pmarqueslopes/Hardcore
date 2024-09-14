using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail : MonoBehaviour
{
    public GameObject redTrail;
    public GameObject greenTrail;
    public GameObject blueTrail;

    public PlayerUnit playerUnit;
    [SerializeField] int red;
    [SerializeField] int green;
    [SerializeField] int blue;
    
    void Start()
    {   
        switch (playerUnit.equipedGemSingle)
        {
            case "Blue":
                blue++;
                break;
            case "Green":
                green++;
            
                break;
            case "Red":
                red++;
                break;
            
        }
        switch (playerUnit.equipedGemMultiple)
        {
            case "Blue":
                blue++;
                break;
            case "Green":
                green++;
            
                break;
            case "Red":
                red++;
                break;
        }
        switch (playerUnit.equipedGemPower)
        {
            case "Blue":
                blue++;
                break;
            case "Green":
                green++;
            
                break;
            case "Red":
                red++;
                break;
        }

        if (red > green && red > blue)
        {
            redTrail.SetActive(true);
        }
        else if (green > red && green > blue)
        {
            greenTrail.SetActive(true);
        }
        else if (blue > red && blue > green)
        {
            blueTrail.SetActive(true);
        }
    }

   
}
