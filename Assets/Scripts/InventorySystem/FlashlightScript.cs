/*
Este script representa el comportamiento de un objeto linterna en el juego.
La linterna puede encenderse y apagarse, y el jugador puede interactuar con ella para tomarla en la mano.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour, IInteractable, IStorable
{
    public GameObject PlayerFlashlight; // Referencia al componente de linterna en el brazo izquierdo del modelo del jugador.
    public bool switchFlashlight; // Estado actual de la linterna (encendida/apagada).
    public GameObject lightPoint; // Punto de luz de la linterna.

    void Update()
    {
        if (PlayerFlashlight.activeInHierarchy) //Verificamos si esta activo en Hierarchy
        {
            if (switchFlashlight)   //Cambiamos el estado de la linterna
            {
                lightPoint.SetActive(true);
            }
            else
            {
                lightPoint.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.F)) //Intercambiamos el estado de linterna, de Encendido a Apagado o viceversa 
            {
                switchFlashlight = !switchFlashlight;
            }
        }
    }

    // Implementación de la función de la interfaz IInteractable.
    // Al interactuar, el jugador activa la linterna y esta se desactiva en la escena.
    public void Interact()
    {
        PlayerFlashlight.SetActive(true);// Activar la linterna en la mano del jugador.
        this.gameObject.SetActive(false);// Desactivar la linterna en el escenario.
    }
    //Luego invocamos Store para guardar el item en el inventario.
    public void Store()
    {
        // Aqui se agregara la logica para guardar la linterna en el inventario del jugador.
    }

}
