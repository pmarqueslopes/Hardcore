using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class miniMapa : MonoBehaviour
 {
    public Transform player;
    private void LateUpdate(){
            Vector3 posicaoPlayer = player.position;
            posicaoPlayer.y=transform.position.y;
            transform.position=posicaoPlayer;
    }
    
}
