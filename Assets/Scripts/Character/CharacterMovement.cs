/* Esta clase act�a como un m�todo del movimiento del personaje, modificando las velocidades en las que se mueve el */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterMovement : NetworkBehaviour
{
    //Esta variable har� referencia al objeto que contiene el Script que necesitemos acceder//
    public CharacterInput characterInput;

    //Estas dos variables almacena las velocidades iniciales de movimiento y la rotaci�n//
    public float speedMov = 5.0f;
    public float speedRotate = 200.0f;

    //Estas variables almacenan la velocidad de movimiento al cual necesitamos regresar//
    public float speed0;
    public float speedCouch;

    // Start is called before the first frame update
    void Start()
    {
        speed0 = speedMov; //Inicializamos la velocidad del movimiento
        speedCouch = speedMov * 0.5f; //Inicializamos la velocidad del movimiento de cu�ndo est� agachado
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
    }

    //M�todo que mover� y rotar� a mi personaje al nuevo vector3 establecido normalizado//
    public void Movement()
    {        
        //Queremos rotar o movernos dependiendo de x e y
        transform.Rotate(0, characterInput.x * Time.deltaTime * speedRotate, 0);
        transform.Translate(0, 0, characterInput.y * Time.deltaTime * speedMov);        
    }
}
