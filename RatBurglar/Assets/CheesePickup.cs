using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using Unity.Netcode;

public class CheesePickup : NetworkBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public bool withinRange = false;
    public GameObject player = null;
    Transform parent = null;
    public Collider cheeseCollider;
    public Rigidbody m_rigidbody;
    void Update()
    {
        
        if(withinRange && Input.GetKeyDown("q") && !this.transform.IsChildOf(player.transform)){
            this.transform.SetParent(player.transform);
            parent = player.transform;
            cheeseCollider.enabled = false;
            m_rigidbody.useGravity = false;
        }
        else if(Input.GetKeyDown("q") && parent){
            this.transform.SetParent(null);
            parent = null;
            cheeseCollider.enabled = true;
            m_rigidbody.useGravity = true;
            //Debug.Log("Triggering this behaviour");
        }
        
    }
    void OnTriggerEnter(Collider other){
        if(other.name == "rat (Clone)"){
            withinRange = true;
            player = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other){
        withinRange = false;
        player = null;
    }
}
