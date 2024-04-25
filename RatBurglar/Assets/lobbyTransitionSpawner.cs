using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Mono.Cecil;
using Unity.VisualScripting;
using System.Data.Common;
public class lobbyTransitionSpawner : NetworkBehaviour
{
    public GameObject playerPrefab;
    public override void OnNetworkSpawn(){
        spawnPlayerServerRpc();
    }
    
    public override void OnNetworkDespawn()
    {
        despawnPlayerServerRpc();
    }
    
    [ServerRpc(RequireOwnership = false)]
    void spawnPlayerServerRpc(ServerRpcParams rpcParams = default){
        //pull the ulong of whoever sent the serverRPC
        ulong clientId = rpcParams.Receive.SenderClientId;
        GameObject player = Instantiate(playerPrefab);
        NetworkObject playerNetworkObject = player.GetComponent<NetworkObject>();
        playerNetworkObject.SpawnAsPlayerObject(clientId);
        
    }
    
    [ServerRpc(RequireOwnership = false)]
    void despawnPlayerServerRpc(ServerRpcParams rpcParams = default){
        //ulong clientId = rpcParams.Receive.SenderClientId;


        foreach(ulong id in NetworkManager.Singleton.ConnectedClientsIds){
            NetworkManager.Singleton.ConnectedClients[id].PlayerObject.Despawn();
        }
        
        
    }
}
