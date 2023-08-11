using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkSfx : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void caminarSfx()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/prueba/walkSfx");

    }
}
