using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ClickAndDrag : MonoBehaviour
{
    public float forceAmmount = 500;

    Rigidbody dragObject;
    Vector3 _offset;

    Vector3 _orginalPosition;
    float _selectionDistance;


    private void Update()
    {
        //creates a Ray from mousePosition
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) //if user inputs left mouse button
        { 
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, Mathf.Infinity)) //casts ray, outputting hitInfo to RaycastHit hit, casts for infinite length
            {
                //sets _selectionDistance to be the distance from ray origin and the hit point
                _selectionDistance = Vector3.Distance(ray.origin, hit.point);

                //sets the dragObject to the rigidBody of the gameObject hit
                dragObject = hit.rigidbody;
                //sets the offset based off of the mousePositions and the selectionDistance 
                _offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y,
                    _selectionDistance));
                //sets originalPosition to be the hit gameObjects transform position
                _orginalPosition = hit.collider.transform.position;
            }

        }
        
        if(Input.GetMouseButtonUp(0)) //if user stops pressing left mouse button
        {
            //sets dragObject to null
            dragObject = null;
        }

    }

    private void FixedUpdate()
    {
        if(dragObject) //if dragObject exists
        {
            //creates a mousePositionOffset and sets it based off of mousePosition and selectionDistance - originalPosition
            Vector3 mousePositionOffset = Camera.main.ScreenToWorldPoint(new Vector3
            (Input.mousePosition.x,
                Input.mousePosition.y,
                _selectionDistance)) - _orginalPosition;
            //sets dragObject velocity calculated from mousemovement from the object
            dragObject.velocity = (_orginalPosition + mousePositionOffset - dragObject.transform.position)
                                  * forceAmmount * Time.deltaTime;
        }
    }
}
