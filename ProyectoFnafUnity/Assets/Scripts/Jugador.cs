using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;

public class Jugador : MonoBehaviour
{
    public int vida;
    float contadorReiniciarEscena;

    float contadorScreamPuppet;
    bool esScreamerPuppet;

    Transform puppet;
    float angulo;

    Transform camara;
    float diferenciaCamaraPuppet;
    public GameObject puppetPrefab;
    public GameObject LucesApagarEscena3Puppet;

    //Sonidos
    public AudioSource JumpScareGenerico;
    public AudioSource CajitaMusical;

    bool cajitaSonando = false;

    void Start()
    {
        vida = 5;
        contadorReiniciarEscena = 0;
        esScreamerPuppet = false;

        puppet = GameObject.FindGameObjectWithTag("Puppet").GetComponent<Transform>();
        puppetPrefab.SetActive(false);
        camara = Camera.main.GetComponent<Transform>();
    }

    void Update()
    {
        // Calculamos el ángulo y normalizamos la diferencia entre -180 y 180 para evitar problemas de rango
        angulo = Herramientas.ObtenerAngulo2D(new Vector2(this.transform.position.x, this.transform.position.z), new Vector2(puppet.position.x, puppet.position.z));
        diferenciaCamaraPuppet = angulo - camara.rotation.eulerAngles.y;

        // Normalizar ángulo entre -180 y 180
        diferenciaCamaraPuppet = (diferenciaCamaraPuppet + 180) % 360 - 180;

        if (vida <= 0)
        {
            contadorReiniciarEscena += Time.deltaTime;

            if (contadorReiniciarEscena >= 3)
            {
                SceneManager.LoadScene("00-Juego");
            }
        }

        if (esScreamerPuppet)
        {
            // Reproducimos la cajita musical UNA SOLA VEZ cuando inicia el evento
            if (!cajitaSonando)
            {
                CajitaMusical.Play();
                cajitaSonando = true;
            }

            contadorScreamPuppet += Time.deltaTime;

            if (contadorScreamPuppet >= 10)
            {
                // Detenemos la cajita al terminar los 10 segundos
                if (CajitaMusical.isPlaying)
                {
                    CajitaMusical.Stop();
                }

                // Activo Puppet
                puppetPrefab.SetActive(true);

                // Reviso si estoy viendo a Puppet dentro del rango (-135 a -65)
                if (diferenciaCamaraPuppet <= -65 && diferenciaCamaraPuppet >= -135)
                {
                    // Apago luces
                    LucesApagarEscena3Puppet.SetActive(false);

                    // Sonido De Puppet (Evitamos que se ejecute en bucle si ya está sonando)
                    if (!JumpScareGenerico.isPlaying)
                    {
                        JumpScareGenerico.Play();
                    }

                    // Contador para pasar a la siguiente escena
                    contadorReiniciarEscena += Time.deltaTime;
                    Debug.Log(contadorReiniciarEscena);

                    if (contadorReiniciarEscena >= 2.5f)
                    {
                        SceneManager.LoadScene("00-Juego-2");
                    }
                }
                else
                {
                    contadorReiniciarEscena = 0; // Si miras a otro lado se reinicia el contador
                }
            }
        }
    }

    public void ActivarScreamerPuppet()
    {
        esScreamerPuppet = true;
        cajitaSonando = false; // Permitir que la cajita suene al activarse
    }
}