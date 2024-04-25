using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventinteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ventStatus;
    public Transform player;
    public GameObject ventpoint1;
    public BoxCollider ventpointCollider;
   

    // Update is called once per frame
    void Update()
    {
        if(ventStatus == true && Input.GetKeyDown("e")){
            player.position = ventpointCollider.bounds.center;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.name == "rat (Clone)"){
            ventStatus = true;
            player = other.transform;
            Debug.Log("Hit Collider");
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.name == "rat (Clone)"){
            ventStatus = false;
            player = null;
            //Debug.Log("Hit Collider");
        }
    }
}
