using UnityEngine;
using UnityEngine.Events;

public class TriggerEvento : MonoBehaviour
{
    [SerializeField]UnityEvent evento = new UnityEvent();
    [SerializeField] private string tagRequerido = "Player";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagRequerido)) //Para que ignore la linterna
        {
            evento.Invoke();
        }
    }
}
