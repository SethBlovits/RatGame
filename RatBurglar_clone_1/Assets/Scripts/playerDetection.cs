using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.Netcode;
using UnityEditor.Animations;

public class playerDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius;
    public GameObject sphere;
    public NavMeshAgent navAgent;
    public Animator animator;
    Vector3 size;
    
    void vision(){
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius/2);

        foreach(var collider in colliders){
            if(collider.name == "rat"){
                RaycastHit hit;
                if(Physics.Raycast(transform.position, collider.transform.position - transform.position, out hit,radius/2)){
                    if(hit.collider.name == "rat"){
                    
                        navAgent.destination = collider.transform.position;
                        //animator.SetBool("walking",true);
                        //Debug.Log("Seeing Rat");
                        
                        
                    }
                }
            }
        }
        sphere.transform.localScale=new Vector3(1,1,1)*radius*4f;
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
