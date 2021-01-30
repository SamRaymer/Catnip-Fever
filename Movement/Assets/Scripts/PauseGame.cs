﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    
    // We'll show paused when it's relevant
    public Text pausedText;

    // Are we paused?
    bool isPaused = false;

    // Start is called before the first frame update
    void Start() {
    }

    private void Awake() {
        pausedText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // Notice this is called during pause
        listenForPause();
    }

    void listenForPause() {

        /**
         * What doesn't get stopped or affected
         * FixedUpdate() isn't called
         * Time IS stopped (yay the timer stops)
         *
         *
         */

        if (Input.GetKeyUp(KeyCode.Escape)) {
            isPaused = !isPaused;
        }
        if (isPaused) {
            Time.timeScale = 0;
            pausedText.text = "Paused";
            // Pause audio
            AudioListener.pause = true;
        } else {
            Time.timeScale = 1;
            pausedText.text = "";
            // Resume audio
            AudioListener.pause = false;
        }

    }
}