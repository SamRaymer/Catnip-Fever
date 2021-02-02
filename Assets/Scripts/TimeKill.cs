using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKill : MonoBehaviour
{
    public float Lifetime = 2.0f;

    private float Deathtime;

    // Start is called before the first frame update
    void Start()
    {
        Deathtime = Time.time + Lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > Deathtime)
        {
            Destroy(this.gameObject);
        }
    }
}
