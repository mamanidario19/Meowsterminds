/* En esta clase modificamos la rotación y la posición de la cámara con respecto del personaje */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    //Estas variables harán referencia al objeto que contiene el Script que necesitemos acceder//
    public Character character; //Objeto que me envía su posición
    public CharacterInput characterInput;
    
    //Variable que establece la sensibilidad del mouse//
    public float sensibilityMouse = 100.0f;

    //Variable que establece la distancia que habrá entre la cámara y el personaje//
    public float distance = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Establece la posición del mouse en el centro de la pantalla al inicio
        Vector3 angles = transform.eulerAngles; //Crea una variable angles que almacenará los angulos de este objeto
        characterInput.mouseX = angles.y; //Le asigna los varoles del mouseX en el anguloY de la variable 
        characterInput.mouseY = angles.x; //Le asigna los varoles del mouseY en el anguloX de la variable
    }

    void LateUpdate()
    {
        //En esta if anidado comprobaremos si se está presionando o no el Mouse2//
        if (Input.GetKey(KeyCode.Mouse2))
        {
            Quaternion rotation = Quaternion.Euler(characterInput.mouseY, characterInput.mouseX, 0); //Crea una variable local Rotation y le asigna los varoles de los Input del mouse y 0 en el eje Z
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, distance) + character.transform.position; //Crea una variable local position y le asigna los varoles del Rotation multiplicado por un vector que establece la distancia del objeto en el eje Z, sumado la posición del personaje
            position.y = Mathf.Clamp(position.y, 0.5f, 1.5f); //Establezco un rango mínimo y máximo de la posición de la cámara en el eje Y
            transform.position = position; //Muevo mi cámara a la nueva posición calculada
            transform.LookAt(character.transform.position); //Roto hacia el personaje la dirección a donde está viendo la cámara
        }
        else
        {
            characterInput.mouseY = Mathf.Clamp(characterInput.mouseY, 0.5f, 45.0f); //Establezco un rango mínimo y máximo de la rotación de la cámara en el eje Y 
            Quaternion rotation = Quaternion.Euler(characterInput.mouseY, characterInput.mouseX, 0); //Crea una variable local Rotation y le asigna los varoles de los Input del mouse y 0 en el eje Z
            Vector3 position = rotation * new Vector3(0.0f, 3.0f, -distance) + character.transform.position; //Crea una variable local position y le asigna los varoles del Rotation multiplicado por un vector que establece la distancia del objeto en el eje Z, sumado la posición del personaje
            transform.SetPositionAndRotation(position, rotation); //Modifico la rotación y la posición de la cámara con los valores calculados anteriormente
        }
    }
}
