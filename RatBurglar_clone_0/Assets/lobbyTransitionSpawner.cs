using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Mono.Cecil;
public class lobbyTransitionSpawner : NetworkBehaviour
{
    public GameObject playerPrefab;
    public override void OnNetworkSpawn(){
        spawnPlayerServerRpc();
    }
    [ServerRpc(RequireOwnership = false)]
    void spawnPlayerServerRpc(ServerRpcParams rpcParams = default){
        //pull the ulong of whoever sent the serverRPC
        ulong clientId = rpcParams.Receive.SenderClientId;
        GameObject player = Instantiate(playerPrefab);
        var playerNetworkObject = player.GetComponent<NetworkObject>();
        playerNetworkObject.SpawnAsPlayerObject(clientId);
    }
}
