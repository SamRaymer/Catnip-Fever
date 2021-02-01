using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseController : MonoBehaviour
{
    private PlayerStats playerStats;
    public GameObject catPrefab;
    public GameObject eventSystem;
    GameTimer gameTimer;
    public float secondsBetweenSpawns = 3f;
    public float spawnTimer = 0f;
    private Transform spawnPoint;

    void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        gameTimer = eventSystem.GetComponent<GameTimer>();
        spawnPoint = transform.GetChild(0);
        spawnPoint.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0f)
        {
            Instantiate(catPrefab, spawnPoint.position, Quaternion.identity);
            spawnTimer += secondsBetweenSpawns;
        }

        if (spawnTimer > 0f && gameTimer.timerIsRunning) {
            spawnTimer -= Time.deltaTime;
        }
    }
}
