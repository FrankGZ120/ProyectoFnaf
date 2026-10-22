using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Linterna")
        {
            Destroy(gameObject,1.2f);
        }
    }
}