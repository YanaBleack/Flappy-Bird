using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private int _damage;

    private void Start()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}
