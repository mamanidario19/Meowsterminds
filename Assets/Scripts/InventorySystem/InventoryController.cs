/*Se encarga de visualizar el inventario */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inv;
    public bool activateInventory;
    public InventoryManager inventoryManager;

    // Update is called once per frame
    void Update()
    {
        if (activateInventory)
        {
            inv.SetActive(true);
            inventoryManager.ListItems();

        }
        else
        {
            inv.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.V))
        {
            activateInventory = !activateInventory;
        }
    }

}
