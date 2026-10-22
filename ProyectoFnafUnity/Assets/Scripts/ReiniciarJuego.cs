using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJuego : MonoBehaviour
{
    public bool puedoReinicar;
    float contador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puedoReinicar)
        {
            contador += Time.deltaTime;
            Debug.Log(contador);

            if (contador >= 11)
            {
                SceneManager.LoadScene("00-Juego");//Aqui que nos lleve a donde quiera
            }

        }
    }

    public void ReinicarJuego()
    {
        puedoReinicar = true;
    }
}
