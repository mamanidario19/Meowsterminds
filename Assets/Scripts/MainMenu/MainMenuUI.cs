using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] Button startHostBtn;
    [SerializeField] Button joinGameBtn;

    // Start is called before the first frame update
    void Start()
    {
        startHostBtn.onClick.AddListener(() => StartLobby());
        joinGameBtn.onClick.AddListener(() => JoinGame());
    }

    private void StartLobby()
    {
        NetworkManager.singleton.StartHost();
    }

    private void JoinGame()
    {
        NetworkManager.singleton.StartClient();
    }
}
