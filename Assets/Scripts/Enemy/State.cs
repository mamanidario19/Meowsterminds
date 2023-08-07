using UnityEngine;
using System.Collections;

//clase padre el cual tendra como herederas color y maquina de estado
//tds nuestros hijos tendran los siguientes atributos
//ES COMO INTERFACE, cuando modifique o agrege alguna otra accion de enemigo no me jode naa
public class State : MonoBehaviour
{
    protected StateMachine stateMachine; //La projeto, es privada pero puede ser usada por clases que hereden donde este definida (Hijas)
    public EnemyAnim enemyAnim; //Para que nuestras clases hijas hereden las animaciones

    //vistual dice que desde una clase que herede de State voy a poder cambiar o reutilizar el metodo
   protected virtual void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
    }

}
