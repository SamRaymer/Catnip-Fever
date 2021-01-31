using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[System.Serializable]
public enum CatMode {
    Midair,
    Wander,
    SprintToLocation,
    SprintToHouse,
}

[System.Serializable]
public enum CatColor {
    Pink, Green, Blue
}

public class CatController : MonoBehaviour {

    public CatColor color = CatColor.Green;
    public CatMode catMode = CatMode.Midair;

    // How far to randomly go
    public float wanderRadius;

    // How long to wander
    public int wanderTimer;

    // On what interval to wander
    public int wanderInterval;

    // Keep track
    private float timer;

    private GameObject cat;

    private int newDir;

    public float velocityFly = 10f;
    public float velocityRun = 5f;
    public float velocityWalk = 1f;

    public float velocity;
    public Vector2 target;
    public GameObject targetObject;
    public float CloseEnough = 0.2f;

    private Vector2 ConstV;
    private Rigidbody2D rigidb;
    private Vector2 direction;
    private Animator animator;

    private float ParkboundL = -3f;
    private float ParkboundR = 6f;
    private float ParkboundU = 19f;
    private float ParkboundB = 10f;

    void Start() {
        velocity = velocityWalk;
        rigidb = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        timer = wanderTimer;
        cat = this.gameObject;
        animator = GetComponent<Animator>();

        if (catMode == CatMode.Wander && (this.transform.position.x < ParkboundL || this.transform.position.x > ParkboundR || this.transform.position.y < ParkboundB || this.transform.position.y > ParkboundU))
        {
            velocity = velocityRun;
            target = GetRandomPointInPark();
        }

        if (catMode == CatMode.Midair)
        {
            velocity = velocityFly;
            target = GetRandomPointInPark();
        }
        
        if (catMode == CatMode.SprintToHouse)
        {
            velocity = velocityRun;
        }
    }

    Vector2 GetRandomPointInPark()
    {
        return new Vector2(Random.Range(ParkboundL, ParkboundR), Random.Range(ParkboundB, ParkboundU));
    }


    // Update is called once per frame
    void Update() {
        if (targetObject != null)
        {
            direction = new Vector2(targetObject.transform.position.x - this.transform.position.x, targetObject.transform.position.y - this.transform.position.y);
        }
        else
        {
            if (target == null || target == new Vector2(0, 0))
            {
                target = GetRandomPointInPark();
            }
            direction = target - new Vector2(this.transform.position.x, this.transform.position.y);
        }

        if (Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y) < CloseEnough)
        {
            if (catMode != CatMode.SprintToHouse)
            {
                velocity = velocityWalk;
                catMode = CatMode.Wander;
                target = GetRandomPointInPark();
            }
            else if (catMode == CatMode.SprintToHouse)
            { 
                Destroy(this.gameObject); 
            }
        }

        ConstV = new Vector2(Mathf.Cos(Mathf.Atan2(direction.y, direction.x)), Mathf.Sin(Mathf.Atan2(direction.y, direction.x))) * velocity;

        rigidb.velocity = ConstV;


        animator.SetFloat("Speed", rigidb.velocity.magnitude);
    }
}
