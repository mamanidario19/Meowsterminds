/* Esta clase actua como un metodo de estado "Estado Persecusion" del Enemigo*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script (Hijo) hereda los atributos de la clase Padre State
public class PersecutionStatus : State
{
    private NavMeshController navMeshController; 
    private VisionController visionController; 
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
        if(!visionController.CanSeePlayer(out hit, true)) //True si miro al jugador
        {
            stateMachine.ActiveState(stateMachine.AlertStatus); //Cambio al estado Alert
            enemyAnim.IsNotRun(); //Dejo de correr
            return;
        }
        agente.SetDestination(playerTrans); //Agente se dirige a la pos de jugador
        
        if (Mathf.Abs(distPlayer.x) < 3.0f && Mathf.Abs(distPlayer.z) < 3.0f) //Si la sitancia del jugador es menor en x y z
        {
            enemyAnim.IsNotRun(); //No corre
            enemyAnim.Idle(); //No camina
            //Perdi
        }
        navMeshController.UpdateDestinationPointNavMeshAgent(); //Controlador actualiza el punto de destino del nav 
	}
}
