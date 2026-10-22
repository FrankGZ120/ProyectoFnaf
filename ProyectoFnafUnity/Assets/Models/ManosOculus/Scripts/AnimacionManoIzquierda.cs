using UnityEngine;
using UnityEngine.InputSystem;

public class AnimacionManoIzquierda : MonoBehaviour
{
    PlayerInput playerInput;
    [SerializeField] RiggeadorManos manoIzquierda;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        manoIzquierda.gripSlider = playerInput.actions["Select Value"].ReadValue<float>();
        manoIzquierda.triggerSlider = playerInput.actions["Activate Value"].ReadValue<float>();
        manoIzquierda.botonAPresionado = playerInput.actions["BotonesFrontales"].IsPressed();
    }
}
