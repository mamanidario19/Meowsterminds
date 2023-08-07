using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RayCast
public class VisionController : MonoBehaviour
{
    public Transform Eyes; //Variable que sirve para usar el RayCast desde el enemigo hacia adelante
    public float visionRange = 15f; //Rayo de Vision
    public Vector3 offset = new Vector3(0f, 0.75f, 0f); //Variable que sirve para sumar en y la pos de eyes

    
    private NavMeshController navMeshController; //Variable que hace ref al controlador NavMeshController

    void Awake()
    {
        navMeshController = GetComponent<NavMeshController>();
    }

    //Metodo que dice si puede ver o no al jugador
    public bool CanSeePlayer(out RaycastHit hit, bool lookPlayer = false)//hit pora ver si el raycast impacto
    {
        Vector3 vectorDirection;
        if (lookPlayer)//Si miramos al jugador
        {
            //pos de jugador restamos la pos de ojos
            vectorDirection = (navMeshController.followTarget.position + offset) - Eyes.position;
        }else
        {
            //Direccion de los ojos hacia adelante
            vectorDirection = Eyes.forward;
        }
        //cuando persigamos enemigo, el nos tratara de mirar siempre, solo pierde vision cuando hay un objeto al frente o cuando sale del rango de vision
        return Physics.Raycast(Eyes.position, vectorDirection, out hit, visionRange) && hit.collider.CompareTag("Player");
        //&& y si es verdadero que tenga el tag player
    }
}
