/* En esta clase llamamos a todas las animaciones cuando se la requieran */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : State
{
    public Animator anim;
    
    //Metodo que ejecutara la animacion idle de no caminar
    public void Idle(){
        anim.SetBool("walk",false);
        
    }
    //Metodo que ejecutara la animacion de caminar
    public void Walk(){
        anim.SetBool("walk",true);
        
    }
    //Metodo que ejecutara la animacion de correr
    public void Run(){
        anim.SetBool("run",true);
         
    }
    //Metodo que ejecutara la animacion de no correr
    public void IsNotRun(){
        anim.SetBool("run",false);
         
    }
}
