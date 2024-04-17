using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class movement : NetworkBehaviour
{
    // Start is called before the first frame update
    public Rigidbody m_rigidbody;
    public bool stuck = false;
    //public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();
    void buttonWatcher(){
        float moveSpeed = 15;
        Vector3 moveVector = Vector3.zero;
        if(Input.GetKey("left shift")){
            
            moveSpeed = 20;
        }  
        if(Input.GetKey("a")){
        
            moveVector += -transform.right*Time.deltaTime*moveSpeed;
            //m_animator.SetBool("isMoving",true);
            //currentMoveSpeedX=-speed;
            //m_animator.SetFloat("Speed%",currentMoveSpeed);
            //m_rigidbody.MovePosition(transform.position - transform.right * Time.deltaTime * speed);
        }
        if(Input.GetKey("d")){

            moveVector += transform.right*Time.deltaTime*moveSpeed;
            //m_animator.SetBool("isMoving",true);
            //m_animator.SetTrigger("WalkTrigger");
            //currentMoveSpeedX=speed;
            //m_animator.SetFloat("Speed%",currentMoveSpeed);
            //m_rigidbody.MovePosition(transform.position + transform.right * Time.deltaTime * speed);
        }
        if(Input.GetKey("w")){
        
            moveVector += transform.forward*Time.deltaTime*moveSpeed;
            //m_animator.SetBool("isMoving",true);
            //m_animator.SetTrigger("WalkTrigger");
            //currentMoveSpeedY=speed;
            //m_animator.SetFloat("Speed%",currentMoveSpeed);
            // m_rigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }
        if(Input.GetKey("s")){

            moveVector += -transform.forward*Time.deltaTime*moveSpeed;
            //m_animator.SetBool("isMoving",true);
            //m_animator.SetTrigger("WalkTrigger");
            //currentMoveSpeedY=-speed;
            //m_animator.SetFloat("Speed%",currentMoveSpeed);
            //m_rigidbody.MovePosition(transform.position - transform.forward * Time.deltaTime * speed);
        }
        m_rigidbody.MovePosition(transform.position+moveVector);
      
        
        /*if(Input.GetKeyDown("space") && canJump){
            jumpBuffered = true;
        }*/
    }
   /* [ServerRpc]
    void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default){
        buttonWatcher();
    }*/
    // Update is called once per frame
    void FixedUpdate() 
    {
        /*if(IsOwner){
            SubmitPositionRequestServerRpc();
        }*/
        //m_rigidbody.MovePosition(Position.Value);
        //if(!IsOwner) return;
        if(!IsOwner) return;
        if(stuck == false){
            buttonWatcher();
        }
        //buttonWatcher();
    }

}

