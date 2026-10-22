using UnityEngine;
using UnityEngine.Splines;

public class MovimientoCarrito : MonoBehaviour
{
    public SplineContainer spline;
    float valor;

    [Header("Controla la velocidad a la que va el jugador")]
    public float velocidadDeMovimiento = 1.5f;

    //Estados
    public bool puedoRecorrer;

    void Start()
    {
        valor = 0;
        puedoRecorrer = false;
    }

    void Update()
    {
        if (puedoRecorrer)
        {
            valor += Time.deltaTime * velocidadDeMovimiento;
            transform.position = spline.EvaluatePosition(valor / spline.CalculateLength());
        }

    }

    public float GetValorActual()
    {
        return valor;
    }

    public void ActivarRecorrido()
    {
        puedoRecorrer = true;
    }

    public void VelocidadCarrito(float vlocidadDada)
    {
        velocidadDeMovimiento = vlocidadDada;
    }
}