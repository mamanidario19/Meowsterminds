/* Esta es la Superclase que va a instanciar a todas las Subclases que la hereden */
using UnityEngine;
using System.Collections;

//Todos nuestros hijos tendran los siguientes atributos
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
