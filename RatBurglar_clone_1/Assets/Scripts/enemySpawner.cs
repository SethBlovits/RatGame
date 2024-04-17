using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class enemySpawner : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public override void OnNetworkSpawn()
    {   
        if(IsServer){
            var instance = Instantiate(enemy,new Vector3(-40, 0, -40), Quaternion.identity);
            
            var instanceNetworkObject = instance.GetComponent<NetworkObject>();
            instanceNetworkObject.Spawn();
        }
        
    }

    // Update is called once per frame
    
}
