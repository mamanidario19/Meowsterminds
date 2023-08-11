/*Scrip encargado de disparar las funciones de la Interfaz IInteractable e IStorable*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class LootScript : MonoBehaviourPunCallbacks, IInteractable, IStorable
{
    public Item Item;
    //Metodo encargado de disparar funcion para interactuar con items

    public void Interact()
    {
        print("Objeto conseguido");
        Store();
        //PhotonNetwork.Destroy(gameObject);
        RequestDestroy();
    }
    //Metodo encargado de disparar funcion para guardar items al inventario
    public void Store()
    {
        InventoryManager.Instance.Add(Item);

    }

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
