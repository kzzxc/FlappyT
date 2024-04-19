using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            bullet.gameObject.SetActive(false);
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
