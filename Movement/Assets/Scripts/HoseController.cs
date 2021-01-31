using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseController : MonoBehaviour
{
    private PlayerStats playerStats;
    public GameObject catPrefab;
    GameTimer gameTimer;
    public float secondsBetweenSpawns = 3f;
    public float spawnTimer = 0f;

    void Start()
    {
        gameTimer = transform.Find("Event System").GetComponent<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0f)
        {
            Instantiate(catPrefab, transform.position, Quaternion.identity);
            spawnTimer += secondsBetweenSpawns;
        }

        if (spawnTimer > 0f && gameTimer.timerIsRunning) {
            spawnTimer -= Time.deltaTime;
        }
    }
}
