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
    //Override dice que queremos sobreescribe el comportamiento de Awake
    protected override void Awake()
    {
        base.Awake();//Hacemos referencia al tipo de la clase que heredamos, hacemos una llamada al Awake de State, termina ese y comienza este
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
            stateMachine.ActiveState(stateMachine.AlertStatus); //Cambio al estado Alert
            enemyAnim.IsNotRun(); //Dejo de correr
            return;
        }
        agente.SetDestination(playerTrans); //Agente se dirige a la pos de jugador
        if (Mathf.Abs(distPlayer.x) < 3.0f && Mathf.Abs(distPlayer.z) < 3.0f)//Si la sitancia del jugador es menor a 3 en el eje x y z
        {
            enemyAnim.IsNotRun(); //No corre
        }
        navMeshController.UpdateDestinationPointNavMeshAgent(); //Controlador actualiza el punto de destino del nav   
	}
}
