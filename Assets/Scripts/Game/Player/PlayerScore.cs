using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int _pointValue;
    [SerializeField] private int _totalScore;
    [SerializeField] private float _timer = 0f;
    [SerializeField] public float timeBetweenIncrements;
    [SerializeField] private bool _insidePointZone = false;

    public static PlayerScore instance;

    private void Awake()
    {
        //sets instance to this script
        instance = this;
        //runs UpdateScoreText function from GameManager
        GameManager.instance.UpdateScoreText(_totalScore);
    }

    // Update is called once per frame
    void Update()
    {
        //if insidePointZone is true
        if (_insidePointZone)
        {
            //increases timer by Time.deltaTime
            _timer += Time.deltaTime;
            //if timer is greater than or equal to timeBetweenIncrements
            if (_timer >= timeBetweenIncrements)
            {
                //resets timer to 0f
                _timer = 0f;
                //totalScore is increased by pointValue
                _totalScore += _pointValue;
                //runs UpdateScoreText function from GameManager
                GameManager.instance.UpdateScoreText(_totalScore);
            }
        }
    }

    public void InsidePointZone(bool state, int value)
    {
        //sets insidePointZone to be the passed in bool state
        _insidePointZone = state;
        //sets pointValue to be the passed in int value
        _pointValue = value;

    }
    public void LeftZone()
    {
        //sets timer to 0f
        _timer = 0f;
    }

    public void LoseScore()
    {
        //totalScore is reduced by 2
        _totalScore -= 2;
        //runs UpdateScoreText function from GameManager
        GameManager.instance.UpdateScoreText(_totalScore);
    }
}
