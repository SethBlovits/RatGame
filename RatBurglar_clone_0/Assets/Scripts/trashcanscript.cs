using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class trashcanscript : MonoBehaviour
{
    public bool trashStatus;
    public GameObject player;
    public bool insideCan = false;
    //public GameObject ventpoint1;
   

    // Update is called once per frame
    void Update()
    {
        if(trashStatus == true && Input.GetKeyDown("e")){
            //player.SetParent(this.transform);
            player.transform.position = transform.position;
            
            //player. = true;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.name == "rat (Clone)"){
            trashStatus = true;
            player = other.gameObject;
            //Debug.Log("Hit Collider");
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.name == "rat (Clone)"){
            trashStatus = false;
            player = null;
            insideCan = false;
            //Debug.Log("Hit Collider");
        }
    }
}
