using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class connectedDoors : MonoBehaviour
{
    // Start is called before the first frame update
    public bool doorStatus;
    public GameObject player;
    public GameObject door_two;
   
   

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
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.name == "rat (Clone)"){
            doorStatus = false;
            player = null;
        }
    }
}
