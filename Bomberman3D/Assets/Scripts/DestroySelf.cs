using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    float delay =1f;
    void Start()
    {
        Destroy(gameObject, delay);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Distructable"))
        {
            Destroy(other.gameObject);

        }
    }
}
