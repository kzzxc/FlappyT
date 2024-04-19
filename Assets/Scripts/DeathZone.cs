using UnityEngine;

public class DeathZone : MonoBehaviour, IInteractable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
        }

        if(collision.TryGetComponent(out Bullet bullet))
        {
            bullet.gameObject.SetActive(false);
        }
    }
}
