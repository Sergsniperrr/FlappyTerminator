using UnityEngine;

public class RocketRemover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rocket rocket))
            rocket.Remove();
    }
}
