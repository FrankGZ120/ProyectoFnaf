using UnityEngine;

public class PintarModeloHover : MonoBehaviour
{
    [SerializeField] GameObject modeloOriginal;
    [SerializeField] GameObject modeloHover;
    bool agarrado;

    void Start()
    {
        modeloOriginal.SetActive(true);
        modeloHover.SetActive(false);
        agarrado = false;
    }

    public void HoverModelo()
    {
        if(agarrado) return; //Si lo estoy agarrando retorna
        modeloOriginal.SetActive(false);
        modeloHover.SetActive(true);
    }

    public void UnHoverModelo()
    {
        modeloOriginal.SetActive(true);
        modeloHover.SetActive(false);
    }

    public void AgarrarModelo()
    {
        agarrado=true;
    }

    public void SoltarModelo()
    {
        agarrado = false;
    }

}
