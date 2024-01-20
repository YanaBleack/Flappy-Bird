using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        
        if (_health <= 0)       
            Die();       
    }  

    private void Die()
    {
       gameObject.SetActive(false);
    }
}
