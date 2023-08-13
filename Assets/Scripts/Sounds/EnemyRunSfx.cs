using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunSfx : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void correrEnemigoSfx()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/enemy/enemySnarlSfx");

    }
}
