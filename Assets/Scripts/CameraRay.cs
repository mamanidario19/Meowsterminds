/* Esta clase act�a como un detector de la c�mara utilizando metodos reservados de las Physics.Ray */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    //En este update vamos a utilizar las f�sicas de una SphereCast para que nos ayude a detectar al personaje en un rango de visi�n de forma circular//
    void Update()
    {
        RaycastHit hit;
        Vector3 p1 = transform.position;
        float distanceToObstacle = 0;
        if (Physics.SphereCast(p1, 3.0f, transform.forward, out hit, 15f))
        {
            distanceToObstacle = hit.distance;
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Player"))
            {
                Debug.LogError("Te estoy viendo!!!!!!!!!");
            }
        }
    }

    //M�todo que me permite ver en la Escena del juego el SphereCast antes de ejecutar el juego//
    private void OnDrawGizmos()
    {
        RaycastHit hit;
        Vector3 p1 = transform.position;
        float distanceToObstacle = 0;
        if (Physics.SphereCast(p1, 3.5f, transform.forward, out hit, 15f))
        {
            distanceToObstacle = hit.distance;
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hit.point, 4.0f);

            if (hit.transform.CompareTag("Player"))
            {
                Debug.LogError("Te estoy viendo!!!!!!!!!");
            }
        }
    }
}