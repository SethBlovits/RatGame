using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class trashcanscript : MonoBehaviour
{
    public bool trashStatus;
    public GameObject player;
    public bool insideCan;
    //public GameObject ventpoint1;
    public Collider m_collider;
    public TMP_Text interact;

    // Update is called once per frame
    void Update()
    {
        if(trashStatus == true && insideCan == false && Input.GetKeyDown("e")){
            //player.SetParent(this.transform);
            m_collider.enabled = false;
            player.transform.position = transform.position;
            player.GetComponent<movement>().stuck = true;
            insideCan = true; 
        }
        else if(insideCan == true && Input.GetKeyDown("e")){
            //player.SetParent(this.transform);
            //m_collider.enabled = false;
            //player.transform.position = transform.position;
            insideCan = false;
            player.GetComponent<movement>().stuck = false; 
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.name == "rat (Clone)"){
            trashStatus = true;
            player = other.gameObject;
            interact.enabled = true;
            //Debug.Log("Hit Collider");
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.name == "rat (Clone)"){
            trashStatus = false;
            player = null;
            insideCan = false;
            m_collider.enabled = true;
            interact.enabled = false;
            //Debug.Log("Hit Collider");
        }
    }
}
