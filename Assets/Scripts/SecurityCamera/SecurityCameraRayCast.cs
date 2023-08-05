using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCameraRayCast : MonoBehaviour
{
    public SecurityCameraAlert securityCameraAlert;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Vector3 p1 = transform.position;
        float distanceToObstacle = 0;
        if (Physics.SphereCast(p1, 3.5f, transform.forward, out hit, 10f))
        {
            distanceToObstacle = hit.distance;
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Player"))
            {
                securityCameraAlert.OnAlert();
                print("Te estoy viendo!!!!!!!!!");
            }
            else
            {
                securityCameraAlert.OffAlert();
            }
        }
    }

    private void OnDrawGizmos()
    {
        RaycastHit hit;
        Vector3 p1 = transform.position;
        float distanceToObstacle = 0;
        if (Physics.SphereCast(p1, 3.5f, transform.forward, out hit, 10f))
        {
            distanceToObstacle = hit.distance;
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hit.point, 3.5f);

            if (hit.transform.CompareTag("Player"))
            {
                Debug.LogError("Te estoy viendo!!!!!!!!!");
            }
        }
    }
}
