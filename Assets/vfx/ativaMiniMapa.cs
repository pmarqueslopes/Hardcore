using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ativaMiniMapa : MonoBehaviour
{
    public GameObject objetoParaAtivarDesativar;     
    public void AtivarDesativarGameObject()   
 {        
 if (objetoParaAtivarDesativar != null)     
     {             
        objetoParaAtivarDesativar.SetActive(!objetoParaAtivarDesativar.activeSelf);         
    }     
}
    public void Update(){
        if(Input.GetKeyDown(KeyCode.M)){
           AtivarDesativarGameObject(); 
        }
    } 
}
