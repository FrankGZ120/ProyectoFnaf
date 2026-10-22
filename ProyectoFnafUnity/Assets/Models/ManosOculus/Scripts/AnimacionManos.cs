using UnityEngine;
using UnityEngine.InputSystem;

public class AnimacionManos : MonoBehaviour
{
    PlayerInput playerInput;

    [SerializeField] RiggeadorManos manoDerecha;
    [SerializeField] RiggeadorManos manoIzquierda;

    public Light luz;
    public Collider triggerLiterna;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        luz.enabled = false;
        triggerLiterna.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        manoIzquierda.gripSlider = playerInput.actions["Select Value Left"].ReadValue<float>();
        manoIzquierda.triggerSlider = playerInput.actions["Activate Value Left"].ReadValue<float>();
        manoIzquierda.botonAPresionado = playerInput.actions["BotonesFrontales Left"].IsPressed();

        manoDerecha.gripSlider = playerInput.actions["Select Value"].ReadValue<float>();
        manoDerecha.triggerSlider = playerInput.actions["Activate Value"].ReadValue<float>();
        bool presionoBotonDerecho = manoDerecha.botonAPresionado = playerInput.actions["BotonesPrimarios"].IsPressed();

        if (presionoBotonDerecho)
        {
            luz.enabled = true;
            triggerLiterna.enabled = true;
        }
        else 
        {
            luz.enabled = false;
            triggerLiterna.enabled = false;
        }

    }
}
