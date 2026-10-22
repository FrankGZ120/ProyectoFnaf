using UnityEngine;

public class DestuirEscena : MonoBehaviour
{
    public GameObject objetoDestuir;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(objetoDestuir);
    }

}
