using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class LobbyPlayerLabel : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected TMP_Text PlayerText;
    [SerializeField] protected Image readyImage, colorImage;
    [SerializeField] private Button kickButton;
    public event Action<ulong> onKickClicked;
    private ulong _clientID;
    private void Start(){
        
        if(IsServer){
            kickButton.gameObject.SetActive(true);
            kickButton.onClick.AddListener(kickUserServerRPC);
        }
        else{
            kickButton.gameObject.SetActive(false);
        }
    }
    public void setPlayerName(ulong playerName)
    {
        _clientID = playerName;
        PlayerText.text = "Player "+playerName;
        
    }
    private void BtnKick_Clicked()
    {
        onKickClicked?.Invoke(_clientID);
    }
    
    public void SetReady(bool ready)
    {
        if (ready)
        {
            readyImage.color = Color.green;
        }
        else
        {
            readyImage.color = Color.red;
        }
    }
    
    public void setKickActive(bool isOn)
    {
        kickButton.gameObject.SetActive(isOn);
    }
    public void SetIconColor(Color color)
    {
        colorImage.color = color;
    }
    [ServerRpc]
    public void kickUserServerRPC(){
        if(!IsServer){
            NetworkManager.Singleton.DisconnectClient(_clientID);
        }
        
    }
    
    
}