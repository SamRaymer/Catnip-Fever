using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject UpCarPrefab;
    public GameObject DownCarPrefab;
    public GameObject UpBikePrefab;
    public GameObject DownBikePrefab;
    public GameObject SoccerPrefab;
    public GameObject WaterPrefab;

    public float BikeInterval = 2.0f;
    public float CarInterval = 2.0f;
    public float SoccerInterval = 0.5f;
    public float WaterInterval = 2.0f;

    public float SoccerBallStart = 1f;
    public float WaterStart = 1f;

    private Vector3 LDBikeSpawn = new Vector3(-7.9f,20f,0f);
    private Vector3 LUBikeSpawn = new Vector3(-7.63f,8f,0f);
    private Vector3 DCarSpawn = new Vector3(-6.28f,20f,0f);
    private Vector3 UCarSpawn = new Vector3(-5.03f,8f,0f);
    private Vector3 RDBikeSpawn = new Vector3(-3.69f,20f,0f);
    private Vector3 RUBikeSpawn = new Vector3(-3.34f,8f,0f);

    private float ParkboundL = -3f;
    private float ParkboundR = 6f;
    private float ParkboundU = 19f;
    private float ParkboundB = 10f;

    public float NextLDBike;
    public float NextLUBike;
    public float NextDCar;
    public float NextUCar;
    public float NextRDBike;
    public float NextRUBike;
    public float NextSoccer;
    public float NextWater;

    // Start is called before the first frame update
    void Start()
    {
        NextLDBike = Time.time + BikeInterval * (1 + Random.Range(0, 1));
        NextLUBike = Time.time + BikeInterval * (1 + Random.Range(0, 1));
        NextDCar =   Time.time + CarInterval * (1 + Random.Range(0, 1));
        NextUCar =   Time.time + CarInterval * (1 + Random.Range(0, 1));
        NextRDBike = Time.time + BikeInterval * (1 + Random.Range(0, 1));
        NextRUBike = Time.time + BikeInterval * (1 + Random.Range(0, 1));

        NextSoccer = Time.time + SoccerBallStart;
        NextWater = Time.time + WaterStart;
    }

    Vector3 ParkBorderGen()
    {
        float a = Random.Range(0f, 3f);

        // Top
        if (a < 1)
        {
            return new Vector3(Random.Range(ParkboundL, ParkboundR), ParkboundU + 1, 0f);
        }
        // Right
        else if (a < 2)
        {
            return new Vector3(ParkboundR + 1, Random.Range(ParkboundB, ParkboundU), 0f);
        }
        // Bot
        else
        {
            return new Vector3(Random.Range(ParkboundL, ParkboundR), ParkboundB - 1, 0f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Spawn bikes and cars
        if(Time.time > NextLDBike)
        {
            NextLDBike = Time.time + BikeInterval * (1 + Random.Range(0f, 1f));
            Instantiate(DownBikePrefab, LDBikeSpawn, new Quaternion(0f, 0f, 0f, 0f));
        }
        if (Time.time > NextLUBike)
        {
            NextLUBike = Time.time + BikeInterval * (1 + Random.Range(0f, 1f));
            Instantiate(UpBikePrefab, LUBikeSpawn, new Quaternion(0f, 0f, 0f, 0f));
        }
        if (Time.time > NextDCar)
        {
            NextDCar = Time.time + CarInterval * (1 + Random.Range(0f, 1f));
            Instantiate(DownCarPrefab, DCarSpawn, new Quaternion(0f, 0f, 0f, 0f));
        }
        if (Time.time > NextUCar)
        {
            NextUCar = Time.time + CarInterval * (1 + Random.Range(0f, 1f));
            Instantiate(UpCarPrefab, UCarSpawn, new Quaternion(0f, 0f, 0f, 0f));
        }
        if (Time.time > NextRDBike)
        {
            NextRDBike = Time.time + BikeInterval * (1 + Random.Range(0f, 1f));
            Instantiate(DownBikePrefab, RDBikeSpawn, new Quaternion(0f, 0f, 0f, 0f));
        }
        if (Time.time > NextRUBike)
        {
            NextRUBike = Time.time + BikeInterval * (1 + Random.Range(0f, 1f));
            Instantiate(UpBikePrefab, RUBikeSpawn, new Quaternion(0f, 0f, 0f, 0f));
        }

        // Soccerballs
        if (Time.time > NextSoccer)
        {
            NextSoccer = Time.time + SoccerInterval * (1 + Random.Range(0f, 1f));
            Vector3 Spawnpoint = ParkBorderGen();
            GameObject a = Instantiate(SoccerPrefab, Spawnpoint, new Quaternion(0f, 0f, 0f, 0f));
            ProjectileBehavoir behavoir = a.GetComponent(typeof(ProjectileBehavoir)) as ProjectileBehavoir;
            behavoir.rotation = Random.Range(30f, 250f);
            behavoir.direction = Random.Range(0f, 360f);
            a.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
            behavoir.velocity = 3f;
        }

        // Watermelons
        if (Time.time > NextWater)
        {
            NextWater = Time.time + WaterInterval * (1 + Random.Range(0f, 1f));
            Vector3 Spawnpoint = ParkBorderGen();
            GameObject a = Instantiate(WaterPrefab, Spawnpoint, new Quaternion(0f, 0f, 0f, 0f));
            ProjectileBehavoir behavoir = a.GetComponent(typeof(ProjectileBehavoir)) as ProjectileBehavoir;
            behavoir.rotation = Random.Range(30f, 250f);
            behavoir.direction = Random.Range(0f, 360f);
            a.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
            behavoir.velocity = Random.Range(1f,4f);
        }
    }
}
