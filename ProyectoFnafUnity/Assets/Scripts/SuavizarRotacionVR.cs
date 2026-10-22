using UnityEngine;

public class SuavizarRotacionVR : MonoBehaviour
{
    [Header("Velocidad de suavizado (Valores bajos = más suave, ideal para VR)")]
    public float velocidadSuavizado = 8f;

    [Header("Corrección de orientación")]
    [Tooltip("Ajusta este valor si el carrito arranca al revés (ej. 180 para voltearlo por completo)")]
    public float offsetRotacionY = 180f;
    private Vector3 posicionAnterior;

    void Start()
    {
        posicionAnterior = transform.position;
    }

    void LateUpdate()
    {
        Vector3 direccionMovimiento = transform.position - posicionAnterior;

        if (direccionMovimiento.sqrMagnitude > 0.00001f)
        {
            // Calculamos la rotación base hacia el frente del movimiento
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccionMovimiento.normalized);

            // Multiplicamos por el offset en Y para corregir si el modelo 3D está al revés
            rotacionObjetivo *= Quaternion.Euler(0, offsetRotacionY, 0);

            // Interpola suavemente para evitar mareos en VR
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, Time.deltaTime * velocidadSuavizado);
        }

        posicionAnterior = transform.position;
    }
}