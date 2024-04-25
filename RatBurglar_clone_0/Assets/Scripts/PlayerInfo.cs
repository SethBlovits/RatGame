using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;
using Unity.Collections;

[System.Serializable]
public struct PlayerInfo:INetworkSerializable,IEquatable<PlayerInfo>{
    public ulong clientId;
    public FixedString128Bytes pName;
    public bool isPlayerReady;
    public PlayerInfo(ulong id){
        clientId = id;
        pName = "";
        isPlayerReady = false;
    }
    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref clientId);
        serializer.SerializeValue(ref pName);
        serializer.SerializeValue(ref isPlayerReady);
    }
    public bool Equals(PlayerInfo other){
        return clientId == other.clientId;
    }
}

