using UnityEngine;

public class Remover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ISpawnable spawnableObject))
            spawnableObject.Die();
    }
}
