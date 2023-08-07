using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script (Hijo) hereda los atributos de la clase Padre State
public class PatrolStatus : State
{
    public Transform[] WayPoints;//Este array contiene los waiPoints
    private NavMeshController navMeshController; //Lo necesito para que el enemigo se dirija a los waypoints
    private VisionController visionController;
    private int nextWayPoint; //Siguiente wayPoint

    protected override void Awake()
    {
        base.Awake();
        navMeshController = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();
    }
	
	void Update () {
        RaycastHit hit;
        //Si puede ver al jugador
        if(visionController.CanSeePlayer(out hit))
        {
            //controlador sigue al objetivo con el hit transform
            navMeshController.followTarget = hit.transform;
            //pasamos al estado de persecusion
            stateMachine.ActiveState(stateMachine.PersecutionStatus);
            //la animacion de este estado es ? ...
           return;
        }
        //Si controlador llego     
        if (navMeshController.Arrived())
        {
            nextWayPoint = (nextWayPoint + 1) % WayPoints.Length; //uso modulo, el resto de lo que quede dividir este valor entre el total de elemtos que hay en el array
            UpdateWayPointDestination(); //Actualiza punto de destino empezamos de 0 nuevamente
        }
	}

    void OnEnable()
    {
        //nextWayPoint = 0; //patrulla empezamos de cero ESTA MAL 
        UpdateWayPointDestination();
        enemyAnim.Walk();//anim xq aca siempre entra en estado patrulla ?
    }

    void UpdateWayPointDestination()
    {
        //cuando entramos a este estado, el controlador actualizara el punto de destino
        navMeshController.UpdateDestinationPointNavMeshAgent(WayPoints[nextWayPoint].position);
       
    }

}
