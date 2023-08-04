/* En esta Clase verificamos las colisiones de la c�mara para reubicarla en caso de que haya un objeto entre la visi�n de ella hacia el personaje */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCameraCollision : MonoBehaviour
{
    //Establecemos variables que almacenan la distancia m�nima y m�xima entre nuestro personaje y la posici�n de la c�mara//
    public float minDistance = 1.0f;
    public float maxDistance = 10.0f;
    //Establecemos una variable para almacenar la velocidad en la cual se va a actualizar la nueva posici�n de la c�mara//
    public float smoothness = 10.0f;
    //Establecemos esta variable para almacenar en todo momento la posici�n que debe tomar la c�mara con las nuevas coordenadas ya calculadas//
    public float distance;
    //Establecemos esta variable para almacenar los datos de la ubicaci�n de la c�mara//
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    //Este Update busca obtener si hay alg�n objeto que est� entre mi c�mara y el personaje//
    void Update()
    {
        Vector3 positionCamera = transform.parent.TransformPoint(direction * maxDistance);

        RaycastHit hit;
        if (Physics.Linecast(transform.parent.position, positionCamera, out hit))
        {
            distance = Mathf.Clamp(hit.distance * 0.85f, minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, direction * distance, smoothness * Time.deltaTime);
    }
}
