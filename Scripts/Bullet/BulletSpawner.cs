using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletSpawner : PoolBullet
{
    [SerializeField] private BulletEnemyMov _bulletPrefab;
    [SerializeField] private Transform _spawnPointBullet;
    [SerializeField] private float _timeSpawn;
    [SerializeField] private float _agroDistance;
   
    private Transform _bird;

    public void SetPlayer(Transform bird)
    {
        _bird = bird;
    }

    private void Start()
    {
        StartCoroutine(AppearIn());
        Initialized(_bulletPrefab);
    }

    private void SetBullet(BulletEnemyMov bullet, Vector3 spawnPoint) 
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = spawnPoint;
    }

    private IEnumerator AppearIn()
    {
        var waitForOneSeconds = new WaitForSeconds(_timeSpawn);

        while (enabled)
        {
            float distToBird = Vector2.Distance(transform.position, _bird.position);
          
            BulletEnemyMov bullet;

            if (TryGetObject(out bullet))
            {                
                    SetBullet(bullet, _spawnPointBullet.transform.position);               
            }

            yield return waitForOneSeconds;
        }
    }
}