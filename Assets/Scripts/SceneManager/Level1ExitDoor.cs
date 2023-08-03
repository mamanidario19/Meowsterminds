using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1ExitDoor : MonoBehaviour
{

    public static bool level2Start;

    // Start is called before the first frame update
    void Start()
    {
        level2Start = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            level2Start = true;
            SceneManager.LoadScene("Level2");
        }
    }
}