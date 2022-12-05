using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int _pointValue;
    [SerializeField] private int _totalScore;
    [SerializeField] private float _timer = 0f;
    [SerializeField] public float _timeBetweenIncrements;
    [SerializeField] private bool _insidePointZone = false;

    public static PlayerScore instance;

    private void Awake()
    {
        instance = this;
        GameManager.instance.UpdateScoreText(_totalScore);
    }

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
                GameManager.instance.UpdateScoreText(_totalScore);
            }
        }
    }

    public void InsidePointZone(bool state, int value)
    {
        _insidePointZone = state;
        _pointValue = value;

    }
    public void LeftZone()
    {
        _timer = 0f;
    }

    public void LoseScore()
    {
        _totalScore -= 2;
        GameManager.instance.UpdateScoreText(_totalScore);
    }
}
