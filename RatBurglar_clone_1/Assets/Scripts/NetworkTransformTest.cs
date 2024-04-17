
using UnityEngine;
using Unity.Netcode;

public class NetworkTransformTest : NetworkBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(IsServer){
            float theta = Time.frameCount/10f;
            transform.position = new Vector3((float)Mathf.Cos(theta),0.0f,(float) Mathf.Sin(theta));
            //Position.Value =  transform.position;
        }
    }
}
