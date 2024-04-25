using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.Netcode;
//using UnityEditor.Animations;
using TMPro;
using UnityEngine.UI;

public class playerDetection : NetworkBehaviour
{
    // Start is called before the first frame update
    public float radius;
    public GameObject sphere;
    public NavMeshAgent navAgent;
    public Animator animator;

    public Collider m_collider;
    public TMP_Text caughtText;
    Vector3 size;
    
    void vision(){
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius/2);

        foreach(var collider in colliders){
            if(collider.name == "rat (Clone)"){
                RaycastHit hit;
                if(Physics.Raycast(transform.position, collider.transform.position - transform.position, out hit,radius/2)){
                    if(hit.collider.name == "rat (Clone)"){
                    
                        navAgent.destination = collider.transform.position;
                        //animator.SetBool("walking",true);
                        //Debug.Log("Seeing Rat");
                        
                        
                    }
                }
            }
        }
        sphere.transform.localScale=new Vector3(1,1,1)*radius;
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "rat (Clone)"){
            other.gameObject.transform.position = new Vector3(-15,2,10);
            StartCoroutine(Delay());

        }   
    }
    IEnumerator Delay(){
        caughtText.enabled = true;
        yield return new WaitForSeconds(3f);
        caughtText.enabled = false;
    }
    void Start(){
        size =  sphere.transform.localScale;
    }
    // Update is called once per frame
    void Update()
    {
        if(navAgent.velocity.sqrMagnitude>0){
            animator.SetBool("walking",true);
        }
        else{
            animator.SetBool("walking",false);
        }
        vision();
        
        //animator.SetBool("walking",false);
    }
}
