using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class rotationScript : NetworkBehaviour
{
    // Start is called before the first frame update
   void buttonWatcher(){
        float moveSpeed = 1;
        Vector3 moveVector = Vector3.zero;
        
        if(Input.GetKey("a")){
        
            moveVector += -Vector3.right*Time.deltaTime*moveSpeed;
            //m_animator.SetBool("isMoving",true);
            //currentMoveSpeedX=-speed;
            //m_animator.SetFloat("Speed%",currentMoveSpeed);
            //m_rigidbody.MovePosition(transform.position - transform.right * Time.deltaTime * speed);
        }
        if(Input.GetKey("d")){

            moveVector += Vector3.right*Time.deltaTime*moveSpeed;
            //m_animator.SetBool("isMoving",true);
            //m_animator.SetTrigger("WalkTrigger");
            //currentMoveSpeedX=speed;
            //m_animator.SetFloat("Speed%",currentMoveSpeed);
            //m_rigidbody.MovePosition(transform.position + transform.right * Time.deltaTime * speed);
        }
        if(Input.GetKey("w")){
        
            moveVector += Vector3.forward*Time.deltaTime*moveSpeed;
            //m_animator.SetBool("isMoving",true);
            //m_animator.SetTrigger("WalkTrigger");
            //currentMoveSpeedY=speed;
            //m_animator.SetFloat("Speed%",currentMoveSpeed);
            // m_rigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }
        if(Input.GetKey("s")){

            moveVector += -Vector3.forward*Time.deltaTime*moveSpeed;
            //m_animator.SetBool("isMoving",true);
            //m_animator.SetTrigger("WalkTrigger");
            //currentMoveSpeedY=-speed;
            //m_animator.SetFloat("Speed%",currentMoveSpeed);
            //m_rigidbody.MovePosition(transform.position - transform.forward * Time.deltaTime * speed);
        }
        
        if(moveVector!= Vector3.zero){
            transform.rotation = Quaternion.LookRotation(moveVector,transform.up);
        }
       
        
        /*if(Input.GetKeyDown("space") && canJump){
            jumpBuffered = true;
        }*/
    }
    void Update(){
        if(!IsOwner) return;
        buttonWatcher();

    }
}
