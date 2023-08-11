using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; //Habilita usar las funciones de Photon
using Photon.Realtime;

public class GestorPhoton : MonoBehaviourPunCallbacks
{

    public static GestorPhoton Instance;

    public GameObject player;
    public Transform spawnPoint;
    public Transform spawnPointEnemy;
    public GameObject enemy;
    public GameObject money;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        PhotonNetwork.AutomaticallySyncScene= true;
    }
    public override void OnConnectedToMaster (){
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby (){
        MenuManager.Instance.OpenMenu("title");
    }

    public void CreateRoom()
    {
        PhotonNetwork.JoinOrCreateRoom("Cuarto", new RoomOptions {MaxPlayers = 5}, TypedLobby.Default); 
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinedRoom(){

        if(PhotonNetwork.IsMasterClient)
        {
            GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
            GameObject _money = PhotonNetwork.Instantiate(money.name, new Vector3(-34.69f, 1.247f, -16.05f), Quaternion.identity);
        }else{
            GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        }
       
        
        //GameObject _enemy = PhotonNetwork.Instantiate(enemy.name, spawnPointEnemy.position, Quaternion.identity);
        
    }

}
