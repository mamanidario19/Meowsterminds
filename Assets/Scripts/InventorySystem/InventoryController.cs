using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inv;
    public bool activateInventory;   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(activateInventory)
        {
            inv.SetActive(true);
        }
        else
        {
            inv.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.V))
        {
            activateInventory = !activateInventory;
        }
    }

}
