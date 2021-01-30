using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavoir : MonoBehaviour
{
    public float velocity = 2.0f;
    public float direction = 0.0f;
    public float rotation = 95.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (new Vector3(0,1,0) * Mathf.Sin(direction) + new Vector3(1, 0, 0) * Mathf.Cos(direction)) * velocity * Time.deltaTime;
        transform.Rotate(0, 0, rotation * Time.deltaTime);
    }
}
