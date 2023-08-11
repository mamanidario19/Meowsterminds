/*
Este script administra las funciones relacionadas con Photon en el juego, como la conexión a la red y la creación de salas.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; //Habilita usar las funciones de Photon
using Photon.Realtime;

public class GestorPhoton : MonoBehaviourPunCallbacks
{

    public static GestorPhoton Instance;

    public GameObject player;
    public Transform spawnPoint; // Punto de aparicion del jugador.
    public Transform spawnPointEnemy; // Punto de aparicion de enemigos.
    public GameObject enemy; //Prefa del enemigo.
    public GameObject money;
    public List<Item> Loot = new List<Item>(); // Lista de objetos obtenibles.

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // Conectar a la red Photon usando las configuraciones.
    }

    // Update is called once per frame
    void Update()
    {
        PhotonNetwork.AutomaticallySyncScene = true; // Sincronizar automaticamente las escenas en Photon.
    }

    // Llamado cuando nos conectamos al servidor maestro de Photon.
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(); // Unirse al lobby despues de conectarse al servidor maestro.
    }

    // Se llama cuando se une al lobby de Photon.
    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("title");// Abrir el menu de título.
    }

    // Crear una sala en Photon.
    public void CreateRoom()
    {
        PhotonNetwork.JoinOrCreateRoom("Cuarto", new RoomOptions { MaxPlayers = 5 }, TypedLobby.Default);
        PhotonNetwork.LoadLevel(1); // Cargamos la escena del juego.
    }

    // Se llama cuando se une a una sala en Photon.
    public override void OnJoinedRoom()
    {
        /*
        Si el jugador es el cliente maestro (host de la sala):
        Instancia al jugador local en el punto de aparicion designado.
        Configura al jugador local (cámara, movimiento)
        */
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();


            // Recorre la lista de objetos interactuables.
            foreach (var item in Loot)
            {
                // Instanciamos cada objeto interactuable en su ubicacion y rotacion designadas.
                PhotonNetwork.Instantiate(item.prefab.name, item.location, item.rotation);
            }
        }
        //Si el jugador no es el cliente maestro no instancia la lista de items:
        else
        {
            GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        }

    }

}


