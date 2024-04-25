using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class moustrapBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player = null;     
    bool playerStuck = false;
    float timeDuration = 0f;
    public TMP_Text trappedText;
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
    IEnumerator Delay(){
        trappedText.enabled = true;
        yield return new WaitForSeconds(3f);
        trappedText.enabled = false;
    }
    void OnTriggerEnter(Collider other){
        if(other.name == "rat (Clone)"){
            player = other.gameObject; 
            playerStuck = true;
            player.GetComponent<movement>().stuck = playerStuck;
            timeDuration = 3f;
            player.transform.position = transform.position;
            StartCoroutine(Delay());
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
