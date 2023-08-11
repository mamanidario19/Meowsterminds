/*Script encargado de la deteccion entre personaje y una entidad */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    /* Detecta un objeto que pertenezca a la interfaz IInteractable*/
    private void OnTriggerStay(Collider obj)
    {
        IInteractable interactable = obj.GetComponent<IInteractable>();
        if (interactable != null && Input.GetKeyDown(KeyCode.E)) //si es IInteractable y Accionamos se ejecuta la funcion de dicha interfaz
        {
            interactable.Interact();
        }
    }
}
