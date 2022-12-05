using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] private int _pointValue = 1;
    [SerializeField] private float _scoreIncrement = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInParent<PlayerScore>().InsidePointZone(true, _pointValue);
            PlayerScore.instance._timeBetweenIncrements = _scoreIncrement;
            Debug.Log(this.gameObject + " detects: " + other.gameObject.tag);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInParent<PlayerScore>().InsidePointZone(false, _pointValue);
            other.GetComponentInParent<PlayerScore>().LeftZone();
        }
    }
}
