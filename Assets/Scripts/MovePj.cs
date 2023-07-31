using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePj : MonoBehaviour
{
    public float speedMov = 5.0f;
    public float speedRotate = 200.0f;
    //para los componenestes de anim
    private Animator anim;
    //para saber si el pj esta idle o en mov
    public float x,y ;


    //JUMP ESTO AL FINAL LO HACE ELIAN
    //CORREGIR
    public Rigidbody rb; 
    public float forceJump = 5f;
    public bool canJump;
    
    //CROUCH
    //guarda el valor de la velocidad de mov xq luego necesitamos regresar 
    public float speed0;
    public float speedCouch;

    void Start()
    {
        canJump = false;
        anim = GetComponent<Animator>();
        speed0 = speedMov;
        speedCouch = speedMov * 0.5f;
    }

    void FixedUpdate(){
        //Queremos rotar o movernos dependiendo de x e y
        transform.Rotate(0,x*Time.deltaTime * speedRotate,0);
        transform.Translate(0,0,y*Time.deltaTime* speedMov);
    }
  
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //referenciamos nuestro animator
        anim.SetFloat("speedX", x);
        anim.SetFloat("speedY", y);

        if(canJump == true){
            if(Input.GetKeyDown(KeyCode.Space)){
                anim.SetBool("jump",true);
                rb.AddForce(new Vector3(0,forceJump, 0),ForceMode.Impulse);
            }

            if(Input.GetKey(KeyCode.C)){
                anim.SetBool("crouch", true);
                speedMov = speedCouch;
            }
            else {
                anim.SetBool("crouch", false);
                speedMov = speed0;
            }

            anim.SetBool("touchGround",true);
        }
        else{
            //  Estoy cayendo
            fallingDown();
        }

    }

    public void fallingDown(){
        anim.SetBool("touchGround",false);
        anim.SetBool("jump",false);
    }
}
