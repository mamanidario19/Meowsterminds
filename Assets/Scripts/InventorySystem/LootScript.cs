/*Scrip encargado de disparar las funciones de la Interfaz IInteractable e IStorable*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour, IInteractable, IStorable
{
    public Item Item;
    //Metodo encargado de disparar funcion para interactuar con items

    public void Interact()
    {
        print("Objeto conseguido");
        Store();
        this.gameObject.SetActive(false);
    }
    //Metodo encargado de disparar funcion para guardar items al inventario
    public void Store()
    {
        InventoryManager.Instance.Add(Item);

    }

}
