/*
Este script se utiliza para configurar el jugador local en el juego, activando los componentes necesarios.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public CharacterInput movement;
    public GameObject camera;

    // Método para configurar al jugador como local.
    public void IsLocalPlayer()
    {
        movement.enabled = true; // Activa el componente de entrada de movimiento.
        camera.SetActive(true); // Activa la cámara del jugador.
    }
}
