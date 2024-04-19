using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField, Range(0, 20)] private float _minspeed;
    [SerializeField, Range(0, 20)] private float _maxspeed;

    private float _speed;

    private void OnValidate()
    {
        if(_minspeed > _maxspeed)
            _maxspeed = _minspeed + 1;
    }

    private void OnEnable()
    {
        _speed = GetRandomSpeed();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    private float GetRandomSpeed()
    {
        return Random.Range(_minspeed, _maxspeed);
    }
}
