using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyAttack : MonoBehaviour
{  
    [SerializeField] private float _agroDistance;
    [SerializeField] private BulletEnemyMov _bullet;
   
    private Transform _bird;

    private float _timer;
    private float _shootDelay = 0.5f;

    public void SetPlayer(Transform bird)
    {
        _bird = bird;
    }

    private void Update() 
    {
        float distToBird = Vector2.Distance(transform.position, _bird.position);

        if (distToBird <= _agroDistance)
        {
            Debug.Log("Выстрел!");
            _timer += Time.deltaTime;

            if (_timer > _shootDelay)
            {
                _timer = 0;
                StartShoot();
            }         
        }
        else       
            Debug.Log("Спит!");        
    }

    private void StartShoot()
    {
        Instantiate(_bullet, transform.position, Quaternion.identity); // обращение к пулу объекта пули
    }
}