using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; //Habilita usar las funciones de Photon
using Photon.Realtime;

public class GestorPhoton : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public Transform spawnPoint;
    public Transform spawnPointEnemy;
    public GameObject enemy;
    public GameObject money;

    //propiedades jugador
   /*  ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();

    //
    public static NetworkManager instancia; */
    // Start is called before the first frame update
    private void Awake() {
        /* instancia = this; */
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster (){
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby (){
        PhotonNetwork.JoinOrCreateRoom("Cuarto", new RoomOptions {MaxPlayers = 5}, TypedLobby.Default);
    }

    public override void OnJoinedRoom(){
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        //GameObject _enemy = PhotonNetwork.Instantiate(enemy.name, spawnPointEnemy.position, Quaternion.identity);
        GameObject _money = PhotonNetwork.Instantiate(money.name, new Vector3(-34.69f, 1.247f, -16.05f), Quaternion.identity);
    }

    /* public voir ColocarNombreJugador(string name){

    } */

    

}
