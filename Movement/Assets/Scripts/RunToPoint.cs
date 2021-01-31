using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToPoint : MonoBehaviour
{
    public float velocity;
    public Vector2 target;
    public GameObject targetObject;
    public float CloseEnough = 1f;

    private Vector2 ConstV;
    private Rigidbody2D rigidb;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rigidb = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            direction = new Vector2(targetObject.transform.position.x - this.transform.position.x, targetObject.transform.position.y - this.transform.position.y);
        }
        else
        {
            direction = target - new Vector2(this.transform.position.x, this.transform.position.y);
        }

        if(Mathf.Sqrt(direction.x*direction.x + direction.y*direction.y) < CloseEnough)
        {
            // do something
        }

        ConstV = new Vector2(Mathf.Cos(Mathf.Atan2(direction.y,direction.x)), Mathf.Sin(Mathf.Atan2(direction.y, direction.x))) * velocity;

        rigidb.velocity = ConstV;
    }
}
