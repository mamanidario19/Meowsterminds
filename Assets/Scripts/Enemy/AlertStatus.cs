/* Esta clase actua como un metodo de estado "Estado Alerta" del Enemigo*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script (Hijo) hereda los atributos de la clase Padre State
public class AlertStatus : State
{
    public float searchSpeed = 60f; //Esta variable sirve para velocidad de busqueda
    public float searchDuration = 4f; //Tiempo que esta girando y buscando a Jugador

    private NavMeshController navMeshController;
    private VisionController visionController;
    private float searchTime; //Tiempo de busqueda

    //Override dice que queremos sobreescribe el comportamiento de Awake
    protected override void Awake()
    {
        base.Awake(); //Hacemos referencia al tipo de la clase que heredamos, hacemos una llamada al Awake de State, termina ese y comienza este
        navMeshController = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();
    }

    void OnEnable()
    {
        navMeshController.StopNavMeshAgent();
        searchTime = 0f;
    }
	
	void Update () {
        RaycastHit hit;
        
        if (visionController.CanSeePlayer(out hit))//Si ve al jugador
        {
            navMeshController.followTarget = hit.transform; //Controlador sigue al objetivo con el hit transform
            stateMachine.ActiveState(stateMachine.PersecutionStatus); //Pasamos al estado de persecusion
            return;
        }
        enemyAnim.Idle(); // No camina
        transform.Rotate(0f, searchSpeed * Time.deltaTime, 0f); //Rotamos en el eje Y
        searchTime += Time.deltaTime; //Tiempo buscado aumenta
        
        if(searchTime >= searchDuration) //Si tiempo buscando es mayor o igual de busqueda
        {
            stateMachine.ActiveState(stateMachine.PatrolStatus); //Seguimos en estado Patrulla
            return;
        }
	}
}
