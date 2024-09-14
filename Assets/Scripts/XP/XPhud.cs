using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPhud : MonoBehaviour
{
    public Slider XPslider;
    public TMP_Text lvlTxt;
    
    void Start()
    {
        AtualizarXP();
    }

    public void AtualizarXP()
    {
        XPslider.value = XPmanager.Instance.currentXP;
        XPslider.maxValue = XPmanager.Instance.maxXP;
        lvlTxt.text = XPmanager.Instance.currentLVL.ToString();
    }
}