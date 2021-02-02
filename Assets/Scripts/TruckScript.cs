using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour
{
    public GameObject nipPrefab;

    private float droptime;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector2(-6.27f, 19.99f);
        droptime = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > droptime)
        {
            Instantiate(nipPrefab, this.transform.position, new Quaternion(0f, 0f, 0f, 0f));
            droptime = Time.time + 100000000;
        }
    }
}
