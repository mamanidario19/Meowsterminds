using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [Header ("Movement")]
    public int routine;
    //tiempo entre rutinas
    public float chronometer;
    public Animator anim;

    public Quaternion degree; //angulo
    public float agle; //grado

    //para q detecte al jugador
    public GameObject target;
    void Start()
    {
        anim = GetComponent<Animator>();
        //detecta al objeto con el target jugadora
        target = GameObject.Find("Marie");
    }
    //faltan comentarios
    //estructura de datos
    //estructura de datos
    //primer principio
    //spawn 
    //patron de diseño maquina de estado
    
    //Creamos este metodo para visualizar el comportamiento del enemigo
    public void enemyBehavior(){

        if(Vector3.Distance(transform.position, target.transform.position) > 5)
        {

            anim.SetBool("run", false); //no corre solo en caso de else
            chronometer += 1 * Time.deltaTime;

            if(chronometer >= 4){
            routine = Random.Range(0, 2); //la rutina elige un num random entre 0 y 1
            chronometer = 0;
            }

            switch(routine){
                case 0:
                    anim.SetBool("walk", false);
                    break;
                case 1:
                    agle = Random.Range(0,360);
                    degree = Quaternion.Euler(0, agle, 0);
                    routine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, degree, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("walk", true);
                    break;
            }   
        } 
        else //Si no esta a 5 de distancia sigue al jugador
        {
            //rota su eje en Y en direccion al jugador
            //variable que sera igual a la pos del jugador menos la pos del enemigo
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            //El enemigo rota segun el angulo de la rotacion del pj con una velocidad de 2
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            anim.SetBool("walk", false);
            anim.SetBool("run", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
        
    }
    
    void Update()
    {
        enemyBehavior();
    }
}
