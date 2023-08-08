/* En esta clase controlamos el NavMeshAgent*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [HideInInspector]
    public Transform followTarget; //Seguir objetivo, en este caso Player
    private NavMeshAgent navMeshAgent; 

	void Awake () {
        navMeshAgent = GetComponent<NavMeshAgent>();
	}
    //Metodo que actualiza punto destino NavMeshAgent
	public void UpdateDestinationPointNavMeshAgent(Vector3 destinationPoint)
    {
        navMeshAgent.destination = destinationPoint; //Su destino sea igual a Punto Destino
        navMeshAgent.isStopped = false ; //Cada que llegamos a un punto continuamos camino
    }
    //Metodo que actualiza el destino nav con la posicion del jugador
    public void UpdateDestinationPointNavMeshAgent()
    {
        UpdateDestinationPointNavMeshAgent(followTarget.position); //Enemigo persigue jugador
    }
    //Metodo que enemigo se detiene, deje de buscar
    public void StopNavMeshAgent()
    {
        navMeshAgent.isStopped = true ;
    }
    //Llegue al objetivo o no?
    public bool Arrived()
    {
        
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending; 
        //Si esta distancia (que falta ) es menor que la que tenemos definida,hemos llegado y no queda mas camino pendiente, no camina mas
    }
}
