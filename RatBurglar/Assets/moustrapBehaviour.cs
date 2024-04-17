using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class moustrapBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player = null;     
    bool playerStuck = false;
    float timeDuration = 0f;
    // Update is called once per frame
    void Update()
    {
        if(playerStuck == true && timeDuration>0){
            timeDuration -= Time.deltaTime;
            
        }
        else{
            playerStuck = false;
            if(player){
                player.GetComponent<movement>().stuck = playerStuck;
            }
            //player.GetComponent<movement>().stuck = playerStuck;
            timeDuration = 0f;
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.name == "rat"){
            player = other.gameObject; 
            playerStuck = true;
            player.GetComponent<movement>().stuck = playerStuck;
            timeDuration = 3f;
            player.transform.position = transform.position;
        }
        
        
    }
    void OnTriggerExit(Collider other){
        if(player){
            player.GetComponent<movement>().stuck = playerStuck;
        }
        //player.GetComponent<movement>().stuck = playerStuck;
        player = null;
        playerStuck = false; 
        
    }
}
