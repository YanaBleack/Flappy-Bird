using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolBullet : MonoBehaviour
{
    [SerializeField] private  BulletEnemyMov _container;
    [SerializeField] private int _capacity;

    private List<BulletEnemyMov> _pool = new List<BulletEnemyMov>();

    protected void Initialized(BulletEnemyMov prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            BulletEnemyMov spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out BulletEnemyMov result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    } 
}