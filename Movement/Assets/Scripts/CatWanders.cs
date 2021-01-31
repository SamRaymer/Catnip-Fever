﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.AI;
using Random = UnityEngine.Random;
 
public class CatWanders : MonoBehaviour {

    public int color;
    public int CatMode = 1;  // 1 = wander, 2 = sprint to location, 3 = sprint to house

    // How far to randomly go
    public float wanderRadius;

    // How long to wander
    public int wanderTimer;

    // On what interval to wander
    public int wanderInterval;

    // Keep track
    private float timer;

    //
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


    private float ParkboundL = -3f;
    private float ParkboundR = 6f;
    private float ParkboundU = 19f;
    private float ParkboundB = 10f;

    void Start() {
        velocity = velocityWalk;
        rigidb = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        timer = wanderTimer;
        cat = this.gameObject;
        // Debug.Log(cat.position);

        if (CatMode != 3 && (this.transform.position.x < ParkboundL || this.transform.position.x > ParkboundR || this.transform.position.y < ParkboundB || this.transform.position.y < ParkboundU))
        {
            velocity = velocityRun;
            target = ParkTargetGen();
        }
        
        if (CatMode == 3)
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
            if (CatMode != 3)
            {
                velocity = velocityWalk;
                CatMode = 1;
                target = ParkTargetGen();
            }
            else if (CatMode == 3)
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
    }
/*
    private void moveCat() {
        //
        newDir = Random.Range(1,4);

        float moveX = 0f;
        float moveY = 0f;

        // N
        if (newDir == 1) {
            moveY = 1f;
        }
        // S
        if (newDir == 2) {
            moveY = -1f;
        }
        // W
        if (newDir == 3) {
            moveX = -1f;
        }
        // W
        if (newDir == 4) {
            moveX = 1f;
        }
        
        // Here's what direction we go
        Vector3 moveDirection = new Vector3(moveX, moveY).normalized;

        rigidb.velocity = moveDirection * velocity;
        //        Vector3 targetMovePosition = this.gameObject.transform.position + moveDirection * 50 * Time.deltaTime;

        //        this.gameObject.transform.position = targetMovePosition;
    }
    */
}