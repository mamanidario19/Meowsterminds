using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; //Habilita usar las funciones de Photon
using Photon.Realtime;

public class GestorPhoton : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
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
        PhotonNetwork.JoinOrCreateRoom("Cuarto", new RoomOptions {MaxPlayers = 2}, TypedLobby.Default);
    }

    public override void OnJoinedRoom(){
        PhotonNetwork.Instantiate("Player", new Vector3(Random.Range(46, 40),0), Quaternion.identity);
    }

}
