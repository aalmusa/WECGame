using UnityEngine;
using System; // For Action

public class HealthPack : MonoBehaviour
{
    public event Action OnCollected; // Define an event that other scripts can subscribe to

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke(); // Trigger the event
            Destroy(gameObject); // Destroy the health pack
        }
    }
}
