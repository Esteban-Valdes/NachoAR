using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoOrbitCamera : MonoBehaviour
{
    public Transform target; // El objeto alrededor del cual orbitar� la c�mara
    public float distance = 10.0f; // Distancia de la c�mara al objeto
    public float orbitSpeed = 10.0f; // Velocidad de la �rbita
    public float yMinLimit = -20f; // L�mite inferior en el eje Y
    public float yMaxLimit = 80f; // L�mite superior en el eje Y
    public float ySpeed = 120.0f; // Velocidad de rotaci�n en el eje Y

    private float x = 0.0f; // �ngulo de rotaci�n en el eje X
    private float y = 0.0f; // �ngulo de rotaci�n en el eje Y

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Aseg�rate de que el cursor est� oculto (opcional)
        Cursor.lockState = CursorLockMode.None;
    }

    void LateUpdate()
    {
        if (target)
        {
            // Rota autom�ticamente en el eje Y (horizontal)
            x += orbitSpeed * Time.deltaTime;

            // Puedes ajustar la rotaci�n en el eje Y para variar la inclinaci�n (opcional)
            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

            // Calcula la nueva rotaci�n y posici�n de la c�mara
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            // Aplica la rotaci�n y posici�n a la c�mara
            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
