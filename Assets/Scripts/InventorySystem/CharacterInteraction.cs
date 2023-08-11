/*
Este script permite la interacción del personaje controlado por el jugador con objetos interactivos cercanos.
Cuando el jugador está cerca de un objeto interactivo y presiona la tecla E, se ejecuta la acción definida en la interfaz IInteractable.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    //Este metodo se llama cuando el jugador PERMANECE(stay) dentro de un colisionador (trigger) de otro objeto.
    private void OnTriggerStay(Collider obj)
    {
        IInteractable interactable = obj.GetComponent<IInteractable>(); // Obtenemos el componente que implementa la interfaz IInteractable del objeto con el que estamos colisionando.
        if (interactable != null && Input.GetKeyDown(KeyCode.E)) // Si es IInteractable y presionamos la tecla E, se ejecuta la funcion de dicha interfaz
        {
            interactable.Interact(); // Ejecuta la función Interact() definida en la interfaz IInteractable.
        }
    }
}
