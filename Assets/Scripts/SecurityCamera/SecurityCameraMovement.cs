using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCameraMovement : MonoBehaviour
{
    public float speed = 10f;
    public float minAngle = 45f;
    public float maxAngle = 135f;
    private float currentAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentAngle += speed * Time.deltaTime;
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);
        if (currentAngle == minAngle || currentAngle == maxAngle)
        {
            speed = -speed;
        }
        transform.Rotate(new Vector3(0f, currentAngle, 0f), speed * Time.deltaTime);
    }
}
