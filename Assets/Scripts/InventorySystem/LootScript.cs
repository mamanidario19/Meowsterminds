/*Scrip encargado de controlar si un objeto fue obtenido y guardado en el inventario, utilizando la Interfaz IInteractable e IStorable
Utiliza Photon para la sincronización en red y se comunica con el GameManager para manejar la recolección de objetos.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class LootScript : MonoBehaviourPunCallbacks, IInteractable, IStorable
{
    public Item Item; // El objeto Item asociado a este objeto obtenido.
    public GameManager gm; // Referencia al GameManager para manejar la recolección de objetos.

    //Metodo llamado en el momento en el que el jugador interactua con un objeto.
    public void Interact()
    {
        print("Objeto conseguido"); //Mesaje por consola
        RequestDestroy(); // Solicita destruccion del objeto obtenido.
        Store(); // Almacena el objeto en el inventario del jugador.
        if (photonView.IsMine)
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            if (gm != null)
            {
                gm.CollectObject(1); // Notifica al GameManager sobre la recolección del objeto (si es el jugador local).
            }
        }
    }
    //Metodo llamado luego de interactuar, para guardar items al inventario.
    public void Store()
    {
        InventoryManager.Instance.Add(Item);
    }
    // Método remoto para destruir el objeto en la red.
    [PunRPC]
    private void DestroyObjectRPC()
    {
        PhotonNetwork.Destroy(gameObject);
    }

    // Solicitar la destrucción del objeto en la red.
    public void RequestDestroy()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // El MasterClient puede destruir el objeto directamente
            PhotonNetwork.Destroy(gameObject);
        }
        else
        {
            // Solicitar la destrucción al MasterClient
            photonView.RPC("DestroyObjectRPC", RpcTarget.MasterClient);
        }
    }


}