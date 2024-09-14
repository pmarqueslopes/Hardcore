using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTeleport : MonoBehaviour
{
    public GameObject Player;
    public GameObject Destinmo;

    public void Teleport()
    {
        Player.transform.position = Destinmo.transform.position;
    }
}

