using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _verticalForce = 0.3f;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    [SerializeField] private float _dividerForRotateDown = 2f;

    private Rigidbody2D _rigidbody;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private Vector2 _startPosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);

        _startPosition = transform.position;
    }

    private void Update()
    {
        Move();
    }

    public void Reset()
    {
        transform.rotation = Quaternion.identity;
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.up * (_verticalForce * Time.deltaTime), ForceMode2D.Impulse);
            transform.rotation = Quaternion.Lerp(transform.rotation, _maxRotation, _rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed / _dividerForRotateDown * Time.deltaTime);
        }
    }
}
