using UnityEngine;
using System.Collections;
public class DATA: MonoBehaviour{
private GameObject [] Datas;
public static float posX, posY, posZ;
void Awake () {
Datas = GameObject. FindGameObjectsWithTag ("DATA");
if (Datas.Length >= 2) {
Destroy (Datas[0]);
}
DontDestroyOnLoad (transform.gameObject);
}
    void Start () {
    if (PlayerPrefs.HasKey("PosX")){
    posX = PlayerPrefs.GetFloat ("PosX");
    }else{
    PlayerPrefs.SetFloat("Posx", posX);
  }
    if (PlayerPrefs.HasKey("PosY")){
    posY = PlayerPrefs.GetFloat ("PosY");
    }else{
    PlayerPrefs.SetFloat ("PosY", posY);
}

         if (PlayerPrefs.HasKey("Posz")){
             posZ= PlayerPrefs.GetFloat ("Posz");
          }else{
                 PlayerPrefs.SetFloat ("Posz", posZ);
                 }
        }
        void Update () {
        if (Input.GetKeyDown ("q")) {
            Application.LoadLevel("World");
        }
}
}
     


