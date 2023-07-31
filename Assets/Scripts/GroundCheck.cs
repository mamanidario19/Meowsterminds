using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public MovePj movePj1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other){
        movePj1.canJump = true;
    }
    private void OnTriggerExit(Collider other){
        movePj1.canJump = false;
    }
}
