/* Esta clase actúa como un método del movimiento del personaje, modificando las velocidades en las que se mueve el */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCrouch : MonoBehaviour
{
    //Estas variables harán referencia al objeto que contiene el Script que necesitemos acceder//
    public CharacterMovement characterMovement;

    //Método que cambia la velocidad del movimiento si está agachado//
    public void IsCrouch()
    {        
        characterMovement.speedMov = characterMovement.speedCouch;
    }

    //Método que retoma la velocidad de mmovimiento cuando no está agachado//
    public void IsNotCrouch()
    {
        characterMovement.speedMov = characterMovement.speed0;
    }
}
