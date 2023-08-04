/* En esta clase gestionaremos los Input obtenidos*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    //Estas variables harán referencia al objeto que contiene el Script que necesitemos acceder//
    public CharacterJump characterJump;
    public CharacterCrouch characterCrouch;
    public CharacterMovement characterMovement;
    public CharacterAnimator characterAnimator;

    public float x, y;
    public float mouseX, mouseY;

    //En este update estableceremos unas condicionales que evaluen cúando van a poder se llamadas sus respectivas funciones ya predefinidas,
    //también almacenamos los valores en X e Y desde sus GetAxis//
    void Update()
    {
        if (characterJump.canJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                characterAnimator.Jump();
                characterJump.Jump();                
            }

            if (Input.GetKey(KeyCode.C))
            {
                characterAnimator.IsCrouch();
                characterCrouch.IsCrouch();                
            }
            else
            {
                characterAnimator.IsNotCrouch();
                characterCrouch.IsNotCrouch();
            }

            characterAnimator.TouchGround();
        }
        else
        {
            characterAnimator.FallingDown();
        }

        x = Input.GetAxis("Horizontal"); 
        y = Input.GetAxis("Vertical"); 

        characterAnimator.Run();
        characterMovement.Movement();

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }

    //En este LateUpdate almacenamos en la variable MouseX y MouseY, los valores obtenidos por el Mouse//
    void LateUpdate()
    {

    }
}
