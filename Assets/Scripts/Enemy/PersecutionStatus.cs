using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script (Hijo) hereda los atributos de la clase Padre State
public class PersecutionStatus : State
{
    private NavMeshController navMeshController; //me sirve 
    private VisionController visionController; //messiii
    public UnityEngine.AI.NavMeshAgent agente;
    public Vector3 distPlayer; //Distancia jugador
    public Vector3 playerTrans; //Transform player

    protected override void Awake()
    {
        base.Awake();
        navMeshController = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();
    }

    void OnEnable()
    {
        enemyAnim.Run(); //En este estado siempre corre
    }
	
	void Update () {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform.position;
        distPlayer = playerTrans - this.transform.position;
        RaycastHit hit;
        //Si no el controlador vision no puede ver al Jugador
        if(!visionController.CanSeePlayer(out hit, true)) //true si miro al jugador
        {
            //Cambio al estado Alert
            stateMachine.ActiveState(stateMachine.AlertStatus); 
            enemyAnim.IsNotRun(); //dejo de correr
            return;
        }
        agente.SetDestination(playerTrans);//Agente se dirige a la pos de jugador
        //Si la sitancia del jugador es menor a 3 o llega
        if (Mathf.Abs(distPlayer.x) < 3.0f && Mathf.Abs(distPlayer.z) < 3.0f)
        {
            enemyAnim.IsNotRun(); //no corre
            enemyAnim.Idle(); //no camina
            //cambio de escena titulo q diga fin ??
        }
        navMeshController.UpdateDestinationPointNavMeshAgent();  //controlador actualiza el punto de destino del nav 
	}
}
