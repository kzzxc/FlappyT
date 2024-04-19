using UnityEngine;

public class Bullet : SpawnableObject, IInteractable
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * (_speed * Time.deltaTime));
    }
}
