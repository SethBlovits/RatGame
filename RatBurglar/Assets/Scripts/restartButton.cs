using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class restartButton : NetworkBehaviour
{
    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(startButtonClick);
        NetworkManager.OnServerStarted += OnServerStarted;
    }
    private void OnServerStarted(){

    }
    // Update is called once per frame
    void startButtonClick(){
        NetworkManager.SceneManager.LoadScene("Lobby",LoadSceneMode.Single);
    }
}
