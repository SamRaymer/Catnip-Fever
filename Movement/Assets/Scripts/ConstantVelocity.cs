using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantVelocity : MonoBehaviour
{
    public float velocity = 2.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * velocity * Time.deltaTime;
    }
}
