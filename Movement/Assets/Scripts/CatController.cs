using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;
using System;
using System.Collections;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[System.Serializable]
public enum CatMode {
    Wander,
    SprintToLocation,
    SprintToHouse,
}

[System.Serializable]
public enum CatColor {
    Pink, Green, Blue
}

[System.Serializable]
public class ColorAnimatorEntry {
    public CatColor color;
    public AnimatorController animator;

    public static ColorAnimatorEntry[] GetEntriesWithoutAnimators()
    {
        return new ColorAnimatorEntry[] {
            new ColorAnimatorEntry{
                color = CatColor.Blue
            },
            new ColorAnimatorEntry{
                color = CatColor.Green
            },
            new ColorAnimatorEntry{
                color = CatColor.Pink
            }
        };
    }
}
 
public class CatController : MonoBehaviour {

    public CatColor color = CatColor.Green;
    public CatMode catMode = CatMode.Wander;  // 1 = wander, 2 = sprint to location, 3 = sprint to house
    public ColorAnimatorEntry[] animators = ColorAnimatorEntry.GetEntriesWithoutAnimators();

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

    public float velocityRun = 5f;
    public float velocityWalk = 1f;

    public float velocity;
    public Vector2 target;
    public GameObject targetObject;
    public float CloseEnough = 0.1f;

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
        // Debug.Log(cat.position);

        if (catMode != CatMode.SprintToHouse && (this.transform.position.x < ParkboundL || this.transform.position.x > ParkboundR || this.transform.position.y < ParkboundB || this.transform.position.y > ParkboundU))
        {
            velocity = velocityRun;
            target = ParkTargetGen();
        }
        
        if (catMode == CatMode.SprintToHouse)
        {
            velocity = velocityRun;
        }
    }

    Vector2 ParkTargetGen()
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
                target = ParkTargetGen();
            }
            direction = target - new Vector2(this.transform.position.x, this.transform.position.y);
        }

        if (Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y) < CloseEnough)
        {
            if (catMode != CatMode.SprintToHouse)
            {
                velocity = velocityWalk;
                catMode = CatMode.Wander;
                target = ParkTargetGen();
            }
            else if (catMode == CatMode.SprintToHouse)
            { Destroy(this.gameObject); }
        }

        ConstV = new Vector2(Mathf.Cos(Mathf.Atan2(direction.y, direction.x)), Mathf.Sin(Mathf.Atan2(direction.y, direction.x))) * velocity;

        rigidb.velocity = ConstV;

        /*else
        {
            timer -= Time.deltaTime;

            //  Keep going!
            if (timer > 0)
            {
                if (Math.Round(timer, 0) % wanderInterval == 0)
                {
                    //
                    timer = timer - 1;
                    //
                    moveCat();
                }
            }
            else
            {
                timer = 0;
            }
        }

        */

        animator.SetFloat("Speed", rigidb.velocity.magnitude);
    }
}
