using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingController : MonoBehaviour
{
    public GameObject armorPanel;
    public GameObject recipesPanel;
    private bool buttonPressed;

    void Start()
    {
        recipesPanel.SetActive(true);
        armorPanel.SetActive(false);
        buttonPressed = false;
    }

    public void ArmaturePanel()
    {
        if(buttonPressed == true)
        {
            armorPanel.SetActive(true);
            recipesPanel.SetActive(false);
            buttonPressed = false;
        }
        else
        {
            armorPanel.SetActive(false);
            recipesPanel.SetActive(true);
            buttonPressed = true;
        }

    }
}
