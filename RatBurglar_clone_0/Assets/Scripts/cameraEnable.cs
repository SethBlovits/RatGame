using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Experimental.Rendering;
public class cameraEnable : NetworkBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public AudioListener audioListener;
    public GameObject rat;
    public override void OnNetworkSpawn(){
        cam.enabled = true;
        if(!IsOwner){
            
            cam.enabled = false;
            audioListener.enabled = false;
        }
        if(IsOwner){
            int Cameraignore = LayerMask.NameToLayer("Cameraignore");
            rat.layer = 8;
            foreach (Transform child in rat.transform)
            {
                 child.gameObject.layer = 8;
            }
        }
    }

   
}
