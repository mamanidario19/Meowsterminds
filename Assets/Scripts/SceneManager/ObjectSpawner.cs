using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject prefab;
    public float tiempoIn = 0;
    public float tiempoRep = 0.1f;
    float xMin = -30f;
    float xMax = 30f;
    float yMin = 20f;
    float yMax = 25f;
    float zMin = -30f;
    float zMax = 30f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Display", tiempoIn, tiempoRep);
    }

    void Display()
    {
        Vector3 randomPosition = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
        Instantiate(prefab, randomPosition, transform.rotation);
    }
}
