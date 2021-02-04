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
    private Animator animator;
    public int framesBeforeCatEmerges = 48;
    private int shootingFrame = 41;

    public GameObject[] catPrefabs = new GameObject[] { null, null, null };

    void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        gameTimer = eventSystem.GetComponent<GameTimer>();
        spawnPoint = transform.GetChild(0);
        spawnPoint.GetComponent<SpriteRenderer>().enabled = false;
        animator = GetComponent<Animator>();
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
            animator.SetTrigger("Shoot");
            shootingFrame = 0;
            spawnTimer += secondsBetweenSpawns;
        }

        if (shootingFrame < framesBeforeCatEmerges)
        {
            Debug.Log(animator.GetCurrentAnimatorStateInfo(0).ToString() + animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Shooting"));
            shootingFrame++;
        }
        if (shootingFrame == framesBeforeCatEmerges)
        {
            MakeCat(spawnPoint.position, Quaternion.identity);
            shootingFrame++;
        }


        if (spawnTimer > 0f && gameTimer.timerIsRunning)
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
