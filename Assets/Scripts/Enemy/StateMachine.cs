/* En esta clase gestionaremos los estados del Enemigo*/
using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour
{
    //Lista de variables donde establecemos las referencias a cada componente de estado
    public State PatrolStatus; //Estado Patrulla
    public State AlertStatus; //Estado Alerta
    public State PersecutionStatus; //Estado Persecusion
    public State InitialState; //Estado Inicial
    public State EnemyAnim;

    private State actualState; //Estado Actual
    void Start()
    {
        ActiveState(InitialState); //Activamos estado inicial
    }
    
    //Para activar un estado nuevo, le pasamos el componente que este actualmente activado
    public void ActiveState(State newState) //Nuevo estado que queramos activar
    {
    if (actualState!=null) //Como estado actual no tiene valor, se ejecuta todo si es distinto de nulo
        actualState.enabled = false; //Desactivamos el estado actual
        actualState = newState; //Asignamos nuevo estado
        actualState.enabled = true; //Activamos nuevo esatdo
    }
}
