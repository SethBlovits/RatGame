using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;
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
    public TMP_InputField inputField;
    public RectTransform rectTransform;
    private void Start(){
        enterButton.onClick.AddListener(EnterEventButton);
        
        inputField.DeactivateInputField();
    }
    public void Update(){
        if(Input.GetKeyDown("t")){
            inputField.ActivateInputField();
            NetworkManager.LocalClient.PlayerObject.GetComponent<movement>().stuck = true;
            rectTransform.localPosition = Vector3.zero;
                
            
        }
        if(Input.GetKeyDown(KeyCode.Return)){
            SendMessageServerRpc(inputText.text);
            inputField.DeactivateInputField();
            NetworkManager.LocalClient.PlayerObject.GetComponent<movement>().stuck = false;
            rectTransform.localPosition = new Vector3(0,2000,0);
            
        }

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
