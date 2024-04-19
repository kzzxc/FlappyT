using UnityEngine;

public class Spawner : Pool
{
    [SerializeField] private SpawnableObject[] _ObjectTemplates;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _secnodsBetweenSpawn;
    [SerializeField] private bool _isRandomSpawnPosition = false;

    private float _elapserTime = 0;

    private float _minValue = -4;
    private float _maxValue = 4;

    private void Start()
    {
        Initialize(_ObjectTemplates);
    }

    private void Update()
    {
        _elapserTime += Time.deltaTime;

        if (_elapserTime > _secnodsBetweenSpawn)
        {
            if (TryGetObject(out SpawnableObject spawnableObject))
            {
                _elapserTime = 0;

                SetObject(spawnableObject);
            }
        }
    }

    private void SetObject(SpawnableObject spawnableObject)
    {
        spawnableObject.gameObject.SetActive(true);

        if (_isRandomSpawnPosition)
        {
            spawnableObject.transform.position = GetRandomSpawnPosition(_spawnPoint.position);
        }
        else
        {
            spawnableObject.transform.position = _spawnPoint.position;
        }
    }

    private Vector3 GetRandomSpawnPosition(Vector3 spawnPoint)
    {
        float distanceY = Random.Range(_minValue, _maxValue);

        return new Vector3(spawnPoint.x, distanceY, 0);
    }
}
