using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRandomPosition : MonoBehaviour
{
    [SerializeField] private Vector2 _xBounds = new Vector2(-15,15);
    [SerializeField] private Vector2 _zBounds = new Vector2(-9, 9);
    [SerializeField] private float _timer = 0f;
    [SerializeField] private float _randomMoveTimer = 0f;

    [SerializeField] public bool _shouldMove = false;

    // Start is called before the first frame update
    void Start()
    {
        NewRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= _randomMoveTimer || _shouldMove)
        {
            _timer = 0f;
            _shouldMove = false;
            NewRandomTime();
            transform.position = new Vector3(Random.Range(_xBounds.x, _xBounds.y), 1f, Random.Range(_zBounds.x, _zBounds.y));
        }
    }

    private void NewRandomTime()
    {
        _randomMoveTimer = Random.Range(1.5f, 3f);
    }
}
