using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class buttonScript : NetworkBehaviour
{
    // Start is called before the first frame update
    public Button startButton;
    public Button hostButton;
    public Button joinButton;
    void Start()
    {
        startButton.onClick.AddListener(startButtonClick);
        hostButton.onClick.AddListener(hostButtonClick);
        joinButton.onClick.AddListener(joinButtonClick);

        NetworkManager.OnServerStarted += OnServerStarted;
        NetworkManager.OnClientStarted += OnClientStarted;

        startButton.gameObject.SetActive(false);
    }
    private void OnServerStarted(){
        startButton.gameObject.SetActive(true);
        Debug.Log("Host Started");

    }
    private void OnClientStarted(){
        if(!IsHost){
            Debug.Log("Client Started");
        }
    }
    private void startButtonClick(){
        NetworkManager.SceneManager.LoadScene("Lobby",LoadSceneMode.Single);
    }
    private void hostButtonClick(){
        NetworkManager.Singleton.StartHost();
    }
    private void joinButtonClick(){
        NetworkManager.Singleton.StartClient();
    }
}
