using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class chatMessageObject : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text chatMessage;

    public void setChatMessage(string name , string message){
        playerName.text = name;
        chatMessage.text = message;
    }
}
