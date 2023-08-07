using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script (Hijo) hereda los atributos de la clase Padre State
public class AlertStatus : State
{
    public float searchSpeed = 60f; //Esta variable sirve para velocidad de busqueda
    public float searchDuration = 4f; //Tiempo que esta girando y buscando a Jugador

    private NavMeshController navMeshController; //ESTO NO va dentro de State
    private VisionController visionController;
    private float searchTime; //Tiempo de busqueda

    //override dice que queremos sobreescribe el comportamiento de Awake, para tener el mismo nivel de acceso (protected virtual void Awake)
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
        //Si ve al jugador
        if (visionController.CanSeePlayer(out hit))
        {
            navMeshController.followTarget = hit.transform;
            stateMachine.ActiveState(stateMachine.PersecutionStatus);
            return;
        }
        //Rotamos en Y 
        enemyAnim.Idle(); //no camineSE PUEDE BORRAR XQ QUEDA TOSCO AUNQUE TMB QUEDA TOSCO SIGUE CAMINANDO MIENTRAS MIRA ALREDEDOR
        transform.Rotate(0f, searchSpeed * Time.deltaTime, 0f);
        searchTime += Time.deltaTime; //tiempo buscado sube
        //Si tiempo buscando es mayor o igual de busqueda
        if(searchTime >= searchDuration)
        {
            //SEGUIMOS en estado patrulla
            stateMachine.ActiveState(stateMachine.PatrolStatus); 
            return;
        }
	}
}
