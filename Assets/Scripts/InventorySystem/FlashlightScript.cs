using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour, IInteractable, IStorable
{
    public GameObject PlayerFlashlight;
    public bool switchFlashlight;   
    public GameObject lightPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerFlashlight.activeInHierarchy)
        {
            if(switchFlashlight)
            {
                lightPoint.SetActive(true);
            }
            else
            {
                lightPoint.SetActive(false);
            }

            if(Input.GetKeyDown(KeyCode.F))
            {
                switchFlashlight = !switchFlashlight;
            }
        }
    }

    public void Interact()
    {
        PlayerFlashlight.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Store()
    {

    }

}
