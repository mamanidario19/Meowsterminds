using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleSfx : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ronronearSfx()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/prueba/purrSfx");
    }
}
