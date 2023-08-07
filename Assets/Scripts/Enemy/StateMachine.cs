using UnityEngine;
using System.Collections;

//Esta clase muestra todos los estados del Enemigo 
public class StateMachine : MonoBehaviour
{
    //Lista de variables donde establecemos las referencias a cada componente de estado
    public State PatrolStatus; //Estado Patrulla
    public State AlertStatus; //Estado Alerta
    public State PersecutionStatus; //Estado Persecusion
    public State InitialState; //Estado Inicial El primero que se inicie
    public State EnemyAnim; //Animaciones


    private State actualState; //Estado Actual Variable de tipo State, me permite acceder a sus atributos
    void Start()
    {
        ActiveState(InitialState); //Activamos estado inicial
    }
    
    public void ActiveState(State newState) //nuevo estado que queramos activar
    {
    if (actualState!=null) //como estado actual no tiene valor, se ejecuta todo si es distinto de nulo
        actualState.enabled = false; //desactivamos el estado actual
        actualState = newState; //asignamos nuevo estado
        actualState.enabled = true; //activamos nuevo esatdo


   }
}
