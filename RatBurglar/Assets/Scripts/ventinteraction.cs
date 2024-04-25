using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ventinteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ventStatus;
    public GameObject player;
    public GameObject ventpoint1;
    public BoxCollider ventpointCollider;
    public TMP_Text interact;
   

    // Update is called once per frame
    void Update()
    {
        if(ventStatus == true && Input.GetKeyDown("e")){
            player.GetComponent<Rigidbody>().MovePosition(ventpointCollider.bounds.center);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.name == "rat (Clone)"){
            ventStatus = true;
            player = other.gameObject;
            //Debug.Log("Hit Collider");
            interact.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.name == "rat (Clone)"){
            ventStatus = false;
            player = null;
            //Debug.Log("Hit Collider");
            interact.enabled = false;
        }
    }
}
