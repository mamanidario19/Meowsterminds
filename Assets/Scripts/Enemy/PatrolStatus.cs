/* Esta clase actua como un metodo de estado "Estado Patrulla" del Enemigo*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script (Hijo) hereda los atributos de la clase Padre State
public class PatrolStatus : State
{
    //public GameObject ListWayPoints;
    public Transform[] WayPoints;//Este array contiene los waiPoints
    private NavMeshController navMeshController; //Lo necesito para que el enemigo se dirija a los waypoints
    private VisionController visionController;

    private int nextWayPoint; //Siguiente wayPoint

    //Override dice que queremos sobreescribe el comportamiento de Awake
    protected override void Awake()
    {
        base.Awake(); //Hacemos referencia al tipo de la clase que heredamos, hacemos una llamada al Awake de State, termina ese y comienza este
        navMeshController = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();
        /*foreach (GameObject WayPoint in ListWayPoints)
        {
            WayPoints.Add(WayPoint.transform);
        }*/
    }
	
	void Update () {
        RaycastHit hit;
        if(visionController.CanSeePlayer(out hit))//Si puede ver al jugador
        {
            
            navMeshController.followTarget = hit.transform; //Controlador sigue al objetivo con el hit transform
            stateMachine.ActiveState(stateMachine.PersecutionStatus); //Pasamos al estado de persecusion
            return;
        }
           
        if (navMeshController.Arrived()) //Si controlador Hemos llegado 
        {
            nextWayPoint = (nextWayPoint + 1) % WayPoints.Length; //Uso modulo, el resto de lo que quede dividir este valor entre el total de elemtos que hay en el array
            UpdateWayPointDestination(); //Actualiza punto de destino, empezamos de 0
        }
	}

    void OnEnable()
    {
        UpdateWayPointDestination();
        enemyAnim.Walk(); //Anim porque aca siempre entra en estado patrulla ?
    }

    void UpdateWayPointDestination()
    {
        //cuando entramos a este estado, el controlador actualizara el punto de destino
        navMeshController.UpdateDestinationPointNavMeshAgent(WayPoints[nextWayPoint].position);
    }

}
