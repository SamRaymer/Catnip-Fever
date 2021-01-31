using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject UpCarPrefab;
    public GameObject DownCarPrefab;
    public GameObject UpBikePrefab;
    public GameObject DownBikePrefab;

    public float NextLDBike;
    public float NextLUBike;
    public float NextDCar;
    public float NextUCar;
    public float NextRDBike;
    public float NextRUBike;

    public float BikeInterval = 2.0f;
    public float CarInterval = 2.0f;

    private Vector3 LDBikeSpawn = new Vector3(-7.9f,20f,0f);
    private Vector3 LUBikeSpawn = new Vector3(-7.63f,8f,0f);
    private Vector3 DCarSpawn = new Vector3(-6.28f,20f,0f);
    private Vector3 UCarSpawn = new Vector3(-5.03f,8f,0f);
    private Vector3 RDBikeSpawn = new Vector3(-3.69f,20f,0f);
    private Vector3 RUBikeSpawn = new Vector3(-3.34f,8f,0f);


    // Start is called before the first frame update
    void Start()
    {
        NextLDBike = Time.time + BikeInterval * (1 + Random.Range(0, 1));
        NextLUBike = Time.time + BikeInterval * (1 + Random.Range(0, 1));
        NextDCar =   Time.time + CarInterval * (1 + Random.Range(0, 1));
        NextUCar =   Time.time + CarInterval * (1 + Random.Range(0, 1));
        NextRDBike = Time.time + BikeInterval * (1 + Random.Range(0, 1));
        NextRUBike = Time.time + BikeInterval * (1 + Random.Range(0, 1));
}

    // Update is called once per frame
    void Update()
    {
        // Spawn bikes and cars
        if(Time.time > NextLDBike)
        {
            NextLDBike = Time.time + BikeInterval * (1 + Random.Range(0, 1));
            Instantiate(DownBikePrefab, LDBikeSpawn, new Quaternion(0f, 0f, 0f, 0f));
        }
        if (Time.time > NextLUBike)
        {
            NextLUBike = Time.time + BikeInterval * (1 + Random.Range(0, 1));
            Instantiate(UpBikePrefab, LUBikeSpawn, new Quaternion(0f, 0f, 0f, 0f));
        }
        if (Time.time > NextDCar)
        {
            NextDCar = Time.time + CarInterval * (1 + Random.Range(0, 1));
            Instantiate(DownCarPrefab, DCarSpawn, new Quaternion(0f, 0f, 0f, 0f));
        }
        if (Time.time > NextUCar)
        {
            NextUCar = Time.time + CarInterval * (1 + Random.Range(0, 1));
            Instantiate(UpCarPrefab, UCarSpawn, new Quaternion(0f, 0f, 0f, 0f));
        }
        if (Time.time > NextRDBike)
        {
            NextRDBike = Time.time + BikeInterval * (1 + Random.Range(0, 1));
            Instantiate(DownBikePrefab, RDBikeSpawn, new Quaternion(0f, 0f, 0f, 0f));
        }
        if (Time.time > NextRUBike)
        {
            NextRUBike = Time.time + BikeInterval * (1 + Random.Range(0, 1));
            Instantiate(UpBikePrefab, RUBikeSpawn, new Quaternion(0f, 0f, 0f, 0f));
        }
    }
}
