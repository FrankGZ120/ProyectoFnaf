using UnityEngine;
using UnityEngine.Splines;

public class FoxyJumpScare : MonoBehaviour
{
    public SplineContainer spline;
    float valor;

    public float velocidadDeMovimiento = 13;

    //Sonido
    public AudioSource JumpScareFoxy;

    //Estados
    public bool puedoRecorrer;

    void Start()
    {
        valor = 0;
        puedoRecorrer = true;
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
        JumpScareFoxy.Play();
    }
}
