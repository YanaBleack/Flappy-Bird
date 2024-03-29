using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score;

    public event UnityAction GameOver;

    public void ResetPlayer()
    {
        _score = 0;
        _mover.ResetBird();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void IncreaseScore()
    {
        _score++;
    }

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }
}