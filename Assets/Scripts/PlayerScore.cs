using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int _totalScore;
    [SerializeField] private float _timer = 0f;
    [SerializeField] private float _timeBetweenIncrements;
    [SerializeField] private bool _insidePointZone = false;

    // Update is called once per frame
    void Update()
    {
        if (_insidePointZone)
        {
            _timer += Time.deltaTime;
            if (_timer > _timeBetweenIncrements)
            {
                _timer = 0f;
                _totalScore += 1;
            }
        }
    }

    public void InsidePointZone(bool state)
    {
        _insidePointZone = state;
    }
    public void LeftZone()
    {
        _timer = 0f;
    }

    public void LoseScore()
    {
        _totalScore -= 2;
    }
}
