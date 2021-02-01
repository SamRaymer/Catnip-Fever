using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseController : MonoBehaviour
{
    private PlayerStats playerStats;
    public GameObject eventSystem;
    GameTimer gameTimer;
    public float secondsBetweenSpawns = 3f;
    public float spawnTimer = 0f;
    public int maxCats = 20;
    public int spawnCount = 0;
    private Transform spawnPoint;

    public GameObject[] catPrefabs = new GameObject[]{null, null, null};

    void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        gameTimer = eventSystem.GetComponent<GameTimer>();
        spawnPoint = transform.GetChild(0);
        spawnPoint.GetComponent<SpriteRenderer>().enabled = false;
    }

    void MakeCat(Vector3 position, Quaternion orientation)
    {
        Instantiate(catPrefabs[spawnCount % catPrefabs.Length], position, orientation);
        spawnCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0f && GameObject.FindGameObjectsWithTag("Cat").Length < maxCats)
        {
            MakeCat(spawnPoint.position, Quaternion.identity);
            spawnTimer += secondsBetweenSpawns;
        }

        if (spawnTimer > 0f && gameTimer.timerIsRunning) {
            spawnTimer -= Time.deltaTime;
        }
    }
}
