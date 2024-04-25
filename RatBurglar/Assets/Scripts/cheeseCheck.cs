using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class cheeseCheck : NetworkBehaviour
{
    // Start is called before the first frame update
    public int cheeseCount;
    public Collider[] hitColliders;
    public float x,y,z;
    bool m_Started;
    
    // Update is called once per frame
    void Start(){
        cheeseCount = 0;
        m_Started = true;
    }
    void FixedUpdate(){
        collisionsManager();
        if(cheeseCount == 0 && IsHost){
            NetworkManager.SceneManager.LoadScene("End Screen",LoadSceneMode.Single);
        }
    }
    void collisionsManager(){
        hitColliders = Physics.OverlapBox(transform.position+new Vector3(120,0,-75),new Vector3(250,50,250)/2,Quaternion.identity,9);
        cheeseCount=0;
        for(int i = 0;i<hitColliders.Length;i++){
            //Debug.Log(hitColliders.Length);
            if(hitColliders[i].gameObject.name.Contains("Cheese_02 1")){
                cheeseCount++;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position+new Vector3(120,0,-75), new Vector3(250,50,250));
    }
    /*
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.name.Contains("Cheese_02 1")){
            cheeseCount++;
        }
    }
    void OnCollisionExit(Collision other) {
        if(other.gameObject.name.Contains("Cheese_02 1")){
            cheeseCount--;
        }    
    }*/
}
