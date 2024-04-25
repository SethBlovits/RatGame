using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;
using System.Security.Principal;
public class chatUI : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Button enterButton;
    [SerializeField]
    private TMP_Text inputText;
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private GameObject message;
    private ulong[] directClientIDs = new ulong[2];
    private void Start(){
        enterButton.onClick.AddListener(EnterEventButton);
    }
    private void EnterEventButton(){
        //NewMessage("player2" , "hello message");
        SendMessageServerRpc(inputText.text);
    }
    private void NewMessage(string messageString,string from){
        GameObject myMessage = Instantiate(message,content.transform);
        myMessage.GetComponent<chatMessageObject>().setChatMessage(from,messageString);
        inputText.text = "";
    }
    [ServerRpc (RequireOwnership = false)]
    private void SendMessageServerRpc(string message,ServerRpcParams serverRpcParams = default){
        
        if(message.StartsWith("@")){
            string[] parts = message.Split(" ");
            string clientIdStr = parts[0].Replace("@","");
            ulong toClientId = ulong.Parse(clientIdStr);

            ServerSendDirectMessage(message,serverRpcParams.Receive.SenderClientId, toClientId);
        }
        else{
            SendMessageClientRpc(message,serverRpcParams.Receive.SenderClientId);
        }
        //SendMessageClientRpc(message,serverRpcParams.Receive.SenderClientId);
    }
    [ClientRpc]
    private void SendMessageClientRpc(string message, ulong clientID){
        NewMessage(message,clientID.ToString());
    }
    private void ServerSendDirectMessage(string message,ulong from,ulong to){
        directClientIDs[0] = from;
        directClientIDs[1] = to;
        ClientRpcParams rpcParams = default;
        rpcParams.Send.TargetClientIds = directClientIDs;

        SendMessageClientRpc("<whisper>" + message,from);
    }
    [ClientRpc]
    private void ReceiveeMessageClientRPC(string message, ulong clientID,ClientRpcParams rpcParams = default){
        NewMessage(message,clientID.ToString());
    }
}
