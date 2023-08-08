/* En esta clase modificamos la rotación y la posición de la cámara en respecto del personaje */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterCameraMovement : NetworkBehaviour
{
    //Estas variables harán referencia al objeto que contiene el Script que necesitemos acceder//
    public CharacterInput characterInput;
    public Transform ObjectToFollow;    
    //Variable que establece la sensibilidad del mouse//
    public float sensibilityMouse = 500.0f;
    //Variable que establece la velocidad de la cámara//
    public float velocityCamera = 120;
    //Variables que almacenarán los nuevos valores a lo cual va a rotar la cámara//
    public float rotY = 0;
    public float rotX = 0;


    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Establece la posición del mouse en el centro de la pantalla al inicio
        Vector3 angles = transform.localRotation.eulerAngles; //Crea una variable angles que almacenará los angulos de este objeto
        rotY = angles.y; //Le asigna los varoles del mouseX en el anguloY de la variable 
        rotX = angles.x; //Le asigna los varoles del mouseY en el anguloX de la variable
    }



    //En este Update, asignaremos a las variables una nueva rotación para el objeto cuando no se este presionando el botón scroll del mouse//
    private void Update()
    {
        rotY += characterInput.mouseX * sensibilityMouse * Time.deltaTime;
        rotX -= characterInput.mouseY * sensibilityMouse * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -60, 60);
        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }

    //En este LateUpdate, verificamos si se presiona o no el botón scroll del mouse para ejecutar las dos distintas posiciones y rotaciones de la cámara//
    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            Vector3 targetPosition = ObjectToFollow.position + ObjectToFollow.forward * 2;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, velocityCamera * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(-ObjectToFollow.forward);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, ObjectToFollow.transform.position, velocityCamera * Time.deltaTime);
        }        
    }
}
