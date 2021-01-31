using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour
{
    public GameObject SeedPrefab;
    public float ShootTime;
    public float nextShot;

    public float v;

    void Start()
    {
        ShootTime = Random.Range(.1f, .5f);
        nextShot = Time.time + ShootTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShot)
        {
            nextShot += ShootTime;
            GameObject a = Instantiate(SeedPrefab, this.transform.position, new Quaternion(0f, 0f, 0f, 0f));
            ProjectileBehavoir behavoir = a.GetComponent(typeof(ProjectileBehavoir)) as ProjectileBehavoir;
            behavoir.rotation = Random.Range(30f, 250f);
            behavoir.direction = this.transform.eulerAngles.z * 180f / Mathf.PI;
            behavoir.velocity = 3f;

            v = this.transform.eulerAngles.z;
        }
    }
}
