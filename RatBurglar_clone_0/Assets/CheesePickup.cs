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
    public NetworkObject netCheese;
    Transform parent = null;
    public Collider cheeseCollider;
    public Rigidbody m_rigidbody;
    void Update()
    {
        
        if(withinRange && Input.GetKeyDown("q") && !this.transform.IsChildOf(player.transform)){
            parent = player.transform;
            if(IsClient){
                clientParentRpc();
            }
            else{
                netCheese.TrySetParent(player);
                //this.transform.SetParent(player.transform);
            }
            
            
            cheeseCollider.enabled = false;
            m_rigidbody.isKinematic = true;
            /*m_rigidbody.useGravity = false;
            m_rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            m_rigidbody.constraints = RigidbodyConstraints.FreezeRotation;*/
        }
        else if(Input.GetKeyDown("q") && parent){
            if(IsClient){
                clientUnparentRpc();
            }
            else{

                //this.transform.SetParent(null);
                netCheese.TryRemoveParent(player);
            }
            
            parent = null;
            cheeseCollider.enabled = true;
            m_rigidbody.isKinematic = false;
           // m_rigidbody.useGravity = true;
            //m_rigidbody.constraints = RigidbodyConstraints.None;
            //Debug.Log("Triggering this behaviour");
        }
        
    }
    [Rpc(SendTo.Server)]
    public void clientParentRpc(){
        
        //this.transform.SetParent(player.transform);
        netCheese.TrySetParent(player);
    }
    [Rpc(SendTo.Server)]
    public void clientUnparentRpc(){
        //this.transform.SetParent(null);
        netCheese.TryRemoveParent();
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
