using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInParent<PlayerScore>().InsidePointZone(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInParent<PlayerScore>().InsidePointZone(false);
            other.GetComponentInParent<PlayerScore>().LeftZone();
        }
    }
}
