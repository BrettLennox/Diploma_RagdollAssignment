using UnityEngine;

public class MoveToRandomPosition : MonoBehaviour
{
    [SerializeField] private Vector2 _xBounds = new Vector2(-15, 15);
    [SerializeField] private Vector2 _zBounds = new Vector2(-9, 9);
    [SerializeField] private float _timer = 0f;
    [SerializeField] private float _randomMoveTimer = 0f;
    [SerializeField] private float _randomMoveMin, _randomMoveMax;

    [SerializeField] public bool shouldMove = false;
    [SerializeField] private bool _isDoublePoint = false;
    [SerializeField] private bool _moveAway;

    // Start is called before the first frame update
    void Start()
    {
        //runs NewRandomTime function on Start
        NewRandomTime();
    }

    // Update is called once per frame
    void Update()
    {

        //increases timer float by Time.deltaTime
        _timer += Time.deltaTime;
        //if timer is greater than or equal to randomMoveTimer OR shouldMove is set to true
        if (_timer >= _randomMoveTimer || shouldMove)
        {
            //resets timer to 0f
            _timer = 0f;
            //resets shouldMove to false
            shouldMove = false;
            //runs NewRandomTime function
            NewRandomTime();
            //if isDoulbePoint is true
            if (_isDoublePoint)
            {
                //if moveAway is true
                if (_moveAway)
                {
                    //sets the transform coordinates to the input Vector3 coordinates
                    transform.position = new Vector3(0, -100, 0);
                    //sets moveAway state to the opposite state
                    _moveAway = !_moveAway;
                }
                //if moveAway is false
                else
                {
                    //sets the transform coordinates to a random Vector3 coordinate from the x and z bounds variables
                    transform.position = new Vector3(Random.Range(_xBounds.x, _xBounds.y), 1f, Random.Range(_zBounds.x, _zBounds.y));
                    //sets moveAway state to the opposite state
                    _moveAway = !_moveAway;
                }
            }
            //if isDoulbePoint is false
            else
            {
                //sets the transform coordinates to a random Vector3 coordinate from the x and z bounds variables
                transform.position = new Vector3(Random.Range(_xBounds.x, _xBounds.y), 1f, Random.Range(_zBounds.x, _zBounds.y));
            }
        }
    }

    private void NewRandomTime()
    {
        //sets the randomMoveTimer to a random float between randomMoveMin and randomMoveMax variables
        _randomMoveTimer = Random.Range(_randomMoveMin, _randomMoveMax);
    }
}
