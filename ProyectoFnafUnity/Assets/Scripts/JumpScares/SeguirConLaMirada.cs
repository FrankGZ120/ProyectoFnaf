using UnityEngine;

public class SeguirConLaMirada : MonoBehaviour
{
    Transform objetoMirar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objetoMirar = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(objetoMirar.position);
        

    }
}
