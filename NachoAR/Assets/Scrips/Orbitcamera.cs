using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoOrbitCamera : MonoBehaviour
{
    public Transform target; // El objeto alrededor del cual orbitará la cámara
    public float distance = 10.0f; // Distancia de la cámara al objeto
    public float orbitSpeed = 10.0f; // Velocidad de la órbita
    public float yMinLimit = -20f; // Límite inferior en el eje Y
    public float yMaxLimit = 80f; // Límite superior en el eje Y
    public float ySpeed = 120.0f; // Velocidad de rotación en el eje Y

    private float x = 0.0f; // Ángulo de rotación en el eje X
    private float y = 0.0f; // Ángulo de rotación en el eje Y

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Asegúrate de que el cursor esté oculto (opcional)
        Cursor.lockState = CursorLockMode.None;
    }

    void LateUpdate()
    {
        if (target)
        {
            // Rota automáticamente en el eje Y (horizontal)
            x += orbitSpeed * Time.deltaTime;

            // Puedes ajustar la rotación en el eje Y para variar la inclinación (opcional)
            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

            // Calcula la nueva rotación y posición de la cámara
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            // Aplica la rotación y posición a la cámara
            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
