using UnityEngine;

public class ActivadorJumpScare : MonoBehaviour
{
    private GameObject objetoJumpScareJugador_1;
    public GameObject prefabJumpScareModelo;
    public GameObject enemigoEnEscena;
    Jugador jugador;

    bool yaSeActivo;

    void Start()
    {
        objetoJumpScareJugador_1 = GameObject.FindGameObjectWithTag("JumpScareObject_1");
        yaSeActivo = false;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!yaSeActivo)
        {
            if (enemigoEnEscena != null)
            {
                yaSeActivo = true;
                jugador.JumpScareGenerico.Play();

                objetoJumpScareJugador_1.SetActive(true);

                GameObject copiaJumpScare = Instantiate(prefabJumpScareModelo, objetoJumpScareJugador_1.transform);
                HacerDaño();
                Debug.Log(jugador.vida);
                Destroy(copiaJumpScare, 1.2f);
                Invoke(nameof(ApagarObjetoJugador), 2f);
            }
        }
    }

    void ApagarObjetoJugador()
    {
        if (objetoJumpScareJugador_1 != null)
        {
            objetoJumpScareJugador_1.SetActive(false);
            jugador.JumpScareGenerico.Stop();
        }
    }

    public void HacerDaño()
    {
        jugador.vida--;
    }
}