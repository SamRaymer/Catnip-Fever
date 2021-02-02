using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavoir : MonoBehaviour
{
    public float velocity = 2.0f;
    public float direction = 0.0f;
    public float rotation = 0.0f;

    private float direction_radians;

    private float despawnTop = 23.0f;
    private float despawnBottom = 5.0f;
    private float despawnLeft = -13.0f;
    private float despawnRight = 9.0f;

    private Vector2 ConstV;
    private Rigidbody2D rigidb;

    // Start is called before the first frame update
    void Start()
    {
        direction_radians = direction * Mathf.PI / 180.0f;

        rigidb = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        ConstV = new Vector2(Mathf.Cos(direction_radians), Mathf.Sin(direction_radians)) * velocity;
    }

    // Update is called once per frame
    void Update()
    {
        rigidb.velocity = ConstV;
        rigidb.angularVelocity = rotation;

        if (transform.position.x > despawnRight || transform.position.x < despawnLeft || transform.position.y > despawnTop || transform.position.y<despawnBottom)
        {
            Destroy(this.gameObject);
        }
    }
}
