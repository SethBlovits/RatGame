using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class cameraEnable : NetworkBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public AudioListener audioListener;
    public override void OnNetworkSpawn(){
        cam.enabled = true;
        if(!IsOwner){
            
            cam.enabled = false;
            audioListener.enabled = false;
        }
    }

   
}
