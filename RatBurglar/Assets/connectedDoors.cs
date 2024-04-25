using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using TMPro;

public class connectedDoors : MonoBehaviour
{
    // Start is called before the first frame update
    public bool doorStatus;
    public GameObject player;
    public GameObject door_two;
    public TMP_Text interact;
   
   

    // Update is called once per frame
    void Update()
    {
        if(doorStatus == true && Input.GetKeyDown("e")){
            player.GetComponent<Rigidbody>().MovePosition(door_two.transform.position);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.name == "rat (Clone)"){
            doorStatus = true;
            player = other.gameObject;
            interact.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.name == "rat (Clone)"){
            doorStatus = false;
            player = null;
            interact.enabled = false;
        }
    }
}
