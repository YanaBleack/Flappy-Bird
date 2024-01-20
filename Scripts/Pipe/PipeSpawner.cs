using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _tempLate;
    [SerializeField] private Transform _bird;
    [SerializeField] private float _secondBetwenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private int _capacity;

    private ObjectPool _pool;
    private float _elapsedTime = 0;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;

        List<GameObject> pipes = new List<GameObject>();

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(_tempLate);
            spawned.GetComponentInChildren<BulletSpawner>().SetPlayer(_bird); 
            spawned.SetActive(false);
            pipes.Add(spawned);
        }

        _pool = new ObjectPool(pipes);
    }

    public void ResetPipes()
    {
        _pool.Reset();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondBetwenSpawn)
        {
            if (_pool.TrySpawn(new Vector3
                (transform.position.x,
                Random.Range(_minSpawnPositionY, _maxSpawnPositionY),
                transform.position.z),
                out GameObject pipe))
            {
                _elapsedTime = 0;
                pipe.GetComponentInChildren<BulletSpawner>(true).gameObject.SetActive(true);
            }
        }
    }
}
