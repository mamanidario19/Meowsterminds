using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyExitDoor : MonoBehaviour
{

    public static bool level1Start;

    // Start is called before the first frame update
    void Start()
    {
        level1Start = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            level1Start = true;
            SceneManager.LoadScene("Level1");
        }
    }
}