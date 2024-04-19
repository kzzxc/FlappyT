using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _firePoint;

    private void Update()
    {
        TryShoot();
    }

    private void TryShoot()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(_bullet, _firePoint.position, transform.rotation);
        }
    }
}
