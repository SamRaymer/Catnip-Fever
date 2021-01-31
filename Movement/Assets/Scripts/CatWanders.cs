using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.AI;
using Random = UnityEngine.Random;
 
public class CatWanders : MonoBehaviour {
 
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


    void Start() {
        timer = wanderTimer;
        cat = this.gameObject;
        // Debug.Log(cat.position);
        
    }

    // Update is called once per frame
    void Update () {
        
        timer -= Time.deltaTime;

        //  Keep going!
        if (timer > 0) {
            if (Math.Round(timer, 0) % wanderInterval == 0) {
                //
                timer = timer - 1;
                //
                moveCat();
            }
        } else {
            timer = 0;
        }
    }

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

        Vector3 targetMovePosition = this.gameObject.transform.position + moveDirection * 50 * Time.deltaTime;

        this.gameObject.transform.position = targetMovePosition;
    }

}