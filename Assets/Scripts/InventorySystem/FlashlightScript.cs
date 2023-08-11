/*Script representativo del objeto Linterna*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour, IInteractable, IStorable
{
    public GameObject PlayerFlashlight; //Componente asignado al brazo izquierdo del modelo
    public bool switchFlashlight; //booleano que representa el estado de la linterna
    public GameObject lightPoint; //Componente Luz dentro del prefab

    void Update()
    {
        if (PlayerFlashlight.activeInHierarchy) //Si esta activo en Hierarchy
        {
            if (switchFlashlight)   //Cambiamos el estado de la linterna
            {
                lightPoint.SetActive(true);
            }
            else
            {
                lightPoint.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.F)) //Intercambiamos el valor de Encendido a Apagado
            {
                switchFlashlight = !switchFlashlight;
            }
        }
    }
    //Al pertenecer a la interfaz IInteactable
    //Primero Colocamos el objeto en la mano del jugador
    public void Interact()
    {
        PlayerFlashlight.SetActive(true);
        this.gameObject.SetActive(false);
    }
    //Luego invocamos Store para guardar el item en el inventario.
    public void Store()
    {

    }

}
