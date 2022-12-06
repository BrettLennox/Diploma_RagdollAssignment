using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] private int _pointValue = 1;
    [SerializeField] private float _scoreIncrement = 0;

    private void OnTriggerStay(Collider other)
    {
        //if trigger event happens with a GameObject tagged "Player"
        if (other.gameObject.tag == "Player")
        {
            //runs InsidePointZone function from the PlayerScore script within Player GameObject
            other.GetComponentInParent<PlayerScore>().InsidePointZone(true, _pointValue);
            //sets timeBetweenIncrements from within PlayerScore to the scoreIncremenet variable within this GameObject
            PlayerScore.instance.timeBetweenIncrements = _scoreIncrement;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if trigger event happens with a GameObject tagged "Player"
        if (other.gameObject.tag == "Player")
        {
            //runs InsidePointZone function from the PlayerScore script within the Player GameObject
            other.GetComponentInParent<PlayerScore>().InsidePointZone(false, _pointValue);
            //runs the LeftZone function from PlayerScore withint the Player GameObject
            other.GetComponentInParent<PlayerScore>().LeftZone();
        }
    }
}
