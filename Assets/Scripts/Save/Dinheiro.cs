using UnityEngine;
using System.Collections;
public class Dinheiro : MonoBehaviour {

void Start () {
    transform.position = new Vector3 (DATA.posX, DATA.posY, DATA.posZ);
    }

private void GetPos()
{
    DATA.posX = transform.position.x;
    DATA.posY = transform.position.y;
    DATA.posZ = transform.position.z;
    
}
void Update () 
{
    if (Input.GetKeyDown ("z")) {
        GetPos();
        PlayerPrefs.SetFloat ("POSX", DATA.posX);
        PlayerPrefs.SetFloat ("PosY", DATA.posY);
        PlayerPrefs. SetFloat ("PosZ", DATA.posZ);
    }
    if (Input.GetKeyDown ("g"))
        {
            Application.LoadLevel("Menu");
        }
         if (Input.GetKeyDown ("q")) 
          {
            Application.LoadLevel("World");
          }
}
           
}
