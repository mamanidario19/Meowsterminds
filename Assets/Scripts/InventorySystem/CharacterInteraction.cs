using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider obj)
    {
        IInteractable interactable = obj.GetComponent<IInteractable>();
        if(interactable !=null && Input.GetKey(KeyCode.E))
        {
            interactable.Interact();
        }
    }
}
