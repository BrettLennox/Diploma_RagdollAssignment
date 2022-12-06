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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        { 
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                _selectionDistance = Vector3.Distance(ray.origin, hit.point);

                dragObject = hit.rigidbody;
                _offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y,
                    _selectionDistance));
                _orginalPosition = hit.collider.transform.position;
            }

        }
        
        if(Input.GetMouseButtonUp(0))
        {
            dragObject = null;
        }

    }

    private void FixedUpdate()
    {
        if(dragObject)
        {
            Vector3 mousePositionOffset = Camera.main.ScreenToWorldPoint(new Vector3
            (Input.mousePosition.x,
                Input.mousePosition.y,
                _selectionDistance)) - _orginalPosition;

            dragObject.velocity = (_orginalPosition + mousePositionOffset - dragObject.transform.position)
                                  * forceAmmount * Time.deltaTime;
        }
    }
}
