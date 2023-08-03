/* En esta clase modificamos la rotaci�n y la posici�n de la c�mara con respecto del personaje */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    //Estas variables har�n referencia al objeto que contiene el Script que necesitemos acceder//
    public Character character; //Objeto que me env�a su posici�n
    public CharacterInput characterInput;
    
    //Variable que establece la sensibilidad del mouse//
    public float sensibilityMouse = 100.0f;

    //Variable que establece la distancia que habr� entre la c�mara y el personaje//
    public float distance = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Establece la posici�n del mouse en el centro de la pantalla al inicio
        Vector3 angles = transform.eulerAngles; //Crea una variable angles que almacenar� los angulos de este objeto
        characterInput.mouseX = angles.y; //Le asigna los varoles del mouseX en el anguloY de la variable 
        characterInput.mouseY = angles.x; //Le asigna los varoles del mouseY en el anguloX de la variable
    }

    void LateUpdate()
    {
        //En esta if anidado comprobaremos si se est� presionando o no el Mouse2//
        if (Input.GetKey(KeyCode.Mouse2))
        {
            Quaternion rotation = Quaternion.Euler(characterInput.mouseY, characterInput.mouseX, 0); //Crea una variable local Rotation y le asigna los varoles de los Input del mouse y 0 en el eje Z
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, distance) + character.transform.position; //Crea una variable local position y le asigna los varoles del Rotation multiplicado por un vector que establece la distancia del objeto en el eje Z, sumado la posici�n del personaje
            position.y = Mathf.Clamp(position.y, 0.5f, 1.5f); //Establezco un rango m�nimo y m�ximo de la posici�n de la c�mara en el eje Y
            transform.position = position; //Muevo mi c�mara a la nueva posici�n calculada
            transform.LookAt(character.transform.position); //Roto hacia el personaje la direcci�n a donde est� viendo la c�mara
        }
        else
        {
            characterInput.mouseY = Mathf.Clamp(characterInput.mouseY, 0.5f, 45.0f); //Establezco un rango m�nimo y m�ximo de la rotaci�n de la c�mara en el eje Y 
            Quaternion rotation = Quaternion.Euler(characterInput.mouseY, characterInput.mouseX, 0); //Crea una variable local Rotation y le asigna los varoles de los Input del mouse y 0 en el eje Z
            Vector3 position = rotation * new Vector3(0.0f, 3.0f, -distance) + character.transform.position; //Crea una variable local position y le asigna los varoles del Rotation multiplicado por un vector que establece la distancia del objeto en el eje Z, sumado la posici�n del personaje
            transform.SetPositionAndRotation(position, rotation); //Modifico la rotaci�n y la posici�n de la c�mara con los valores calculados anteriormente
        }
    }
}
