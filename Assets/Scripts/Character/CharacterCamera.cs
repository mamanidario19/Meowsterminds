using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterCamera : NetworkBehaviour
{
    [SerializeField] private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            camera.enabled = true;
        }
        else
        {
            camera.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
