using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] private int _pointValue = 1;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInParent<PlayerScore>().InsidePointZone(true, _pointValue);
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
