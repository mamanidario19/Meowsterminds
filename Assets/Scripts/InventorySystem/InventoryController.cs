/*
Este script controla la activación y desactivación del inventario en el juego.
El inventario se activa al presionar las teclas I o V, y se desactiva cuando no está en uso.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inv; // Referencia al objeto del inventario en la Hierarchy
    public bool activateInventory; // Estado de activacion del inventario.
    public InventoryManager inventoryManager; // Referencia al administrador del inventario.


    void Update()
    {
        // Activa el inventario y luego a la función que lista los objetos en el inventario,sino desactiva el inventario
        if (activateInventory)
        {
            inv.SetActive(true);
            inventoryManager.ListItems();//
        }
        else
        {
            inv.SetActive(false);
        }
        // Cambia el estado del inventario al presionar las teclas I o V.
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.V))
        {
            activateInventory = !activateInventory;
        }
    }

}
