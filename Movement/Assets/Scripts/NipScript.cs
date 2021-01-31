using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NipScript : MonoBehaviour
{
    public GameObject bluePrefab;
    public GameObject pinkPrefab;
    public GameObject greenPrefab;
    public GameObject playerPrefab;
    public GameObject Spawnmanager;
    public GameObject MiniSpawnManager;
    public SpawnManager s;

    private float t1;
    private float t2;
    private float t3;
    private float t4;
    private float t5;
    private float t6;

    private float tplayer;

    // Start is called before the first frame update
    void Start()
    {
        t1 = Time.time + Random.Range(0.1f, 1f);
        t2 = Time.time + Random.Range(0.1f, 1f);
        t3 = Time.time + Random.Range(0.1f, 1f);
        t4 = Time.time + Random.Range(0.1f, 1f);
        t5 = Time.time + Random.Range(0.1f, 1f);
        t6 = Time.time + Random.Range(0.1f, 1f);

        tplayer = Time.time + 2;

        MiniSpawnManager = GameObject.Find("MiniSpawnManger");
        Spawnmanager = GameObject.Find("SpawnManager");
        s = Spawnmanager.GetComponent(typeof(SpawnManager)) as SpawnManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > t1)
        {
            t1 += 10000000;
            GameObject a = Instantiate(bluePrefab, new Vector2(-9.3f, 11.27f), new Quaternion(0f, 0f, 0f, 0f));
            CatController behavoir = a.GetComponent(typeof(CatController)) as CatController;
            behavoir.targetObject = this.gameObject;
        }
        if (Time.time > t2)
        {
            t2 += 10000000;
            GameObject a = Instantiate(bluePrefab, new Vector2(-9.3f, 11.27f), new Quaternion(0f, 0f, 0f, 0f));
            CatController behavoir = a.GetComponent(typeof(CatController)) as CatController;
            behavoir.targetObject = this.gameObject;
        }
        if (Time.time > t3)
        {
            t3 += 10000000;
            GameObject a = Instantiate(greenPrefab, new Vector2(-9.43f, 14.8f), new Quaternion(0f, 0f, 0f, 0f));
            CatController behavoir = a.GetComponent(typeof(CatController)) as CatController;
            behavoir.targetObject = this.gameObject;
        }
        if (Time.time > t4)
        {
            t4 += 10000000;
            GameObject a = Instantiate(greenPrefab, new Vector2(-9.43f, 14.8f), new Quaternion(0f, 0f, 0f, 0f));
            CatController behavoir = a.GetComponent(typeof(CatController)) as CatController;
            behavoir.targetObject = this.gameObject;
        }
        if (Time.time > t5)
        {
            t5 += 10000000;
            GameObject a = Instantiate(pinkPrefab, new Vector2(-9.4f, 18f), new Quaternion(0f, 0f, 0f, 0f));
            CatController behavoir = a.GetComponent(typeof(CatController)) as CatController;
            behavoir.targetObject = this.gameObject;
        }
        if (Time.time > t6)
        {
            t6 += 10000000;
            GameObject a = Instantiate(pinkPrefab, new Vector2(-9.4f, 18f), new Quaternion(0f, 0f, 0f, 0f));
            CatController behavoir = a.GetComponent(typeof(CatController)) as CatController;
            behavoir.targetObject = this.gameObject;
        }

        if (Time.time > tplayer)
        {
            tplayer += 10000000;
            Instantiate(playerPrefab, new Vector2(-9.4f, 13.8f), new Quaternion(0f, 0f, 0f, 0f));
            MiniSpawnManager.SetActive(false);
            s.Activate();
        }
    }
}
