using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCameraAlert : MonoBehaviour
{
    // Variable pública para establecer el nuevo color de la luz
    public Color newColor = Color.red;

    // Variable para almacenar el color inicial de la luz
    private Color initialColor;

    void Start()
    {
        // Obtén el componente Light del objeto
        Light light = GetComponent<Light>();

        // Almacena el color inicial de la luz
        initialColor = light.color;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void OnAlert()
    {
        Light light = GetComponent<Light>();
        light.color = newColor;
    }

    public void OffAlert()
    {
        Light light = GetComponent<Light>();
        light.color = initialColor;
    }
}
