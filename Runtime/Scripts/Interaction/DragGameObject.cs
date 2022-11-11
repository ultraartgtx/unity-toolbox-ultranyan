using UnityEngine;

public class DragGameObject : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 offset;
    private Vector3 screenPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnMouseDown()
    {
        rb.useGravity = false;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = 
            gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 cursorPoint=new Vector3(Input.mousePosition.x,Input.mousePosition.y,screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint)+offset;
        rb.position = cursorPosition;
        rb.MovePosition(new Vector3(rb.position.x,2f,rb.position.z));
    }

    private void OnMouseUp()
    {
        rb.useGravity = true;
    }
}
