using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class spawnPoints : NetworkBehaviour
{
    // Start is called before the first frame update
    //public GameObject spawnPoint;
    public override void OnNetworkSpawn()
    {
        if (IsOwner) //Only send an RPC to the server on the client that owns the NetworkObject that owns this NetworkBehaviour instance
        {
            //var PlayerObject = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
            var clientId = NetworkManager.Singleton.LocalClient.ClientId;
            transform.position = new Vector3(-100 + (int)clientId,1,-100);
        }

    }

}
