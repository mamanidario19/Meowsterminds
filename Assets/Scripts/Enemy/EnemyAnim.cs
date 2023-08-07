using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : State
{
    //public EnemyInput enemyInput;
    //public EnemyMovement enemyMovement;
    public Animator anim;
    

    public void Idle(){
        anim.SetBool("walk",false);
        
    }
    public void Walk(){
        anim.SetBool("walk",true);
        
    }
    public void Run(){
        anim.SetBool("run",true);
         
    }
    public void IsNotRun(){
        anim.SetBool("run",false);
         
    }
}
