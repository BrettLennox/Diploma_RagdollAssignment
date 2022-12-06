using UnityEngine;

[RequireComponent(typeof(MoveToRandomPosition))]
public class Object : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if collision event happens to a GameObject tagged "Player"
        if(collision.gameObject.tag == "Player")
        {
            //run LoseScore function from PlayerScore on Player GameObject
            collision.gameObject.GetComponentInParent<PlayerScore>().LoseScore();
            //sets shouldMove from MoveToRandomPosition script attached to this Object
            GetComponent<MoveToRandomPosition>().shouldMove = true;
        }
    }
}
