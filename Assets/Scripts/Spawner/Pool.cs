using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<SpawnableObject> _pool = new List<SpawnableObject>();

    protected void Initialize(SpawnableObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            SpawnableObject spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected void Initialize(SpawnableObject[] prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            SpawnableObject spawned = Instantiate(prefabs[randomIndex], _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out SpawnableObject result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}
