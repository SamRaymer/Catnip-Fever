using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    
    // We'll show paused when it's relevant
    // public Text pausedText;
    public Button thePauseButton;
    public GameObject thePausePanel;

    // Are we paused?
    public bool isPaused = false;

    private void Start() {
        thePausePanel.gameObject.SetActive(false);
        thePauseButton.gameObject.SetActive(false);
        // pausedText.gameObject.SetActive(false);
    }

    public void Update()
    {

        /**
         * What doesn't get stopped or affected
         * FixedUpdate() isn't called
         * Time IS stopped (yay the timer stops)
         */

        if (Input.GetKeyUp(KeyCode.Escape)) {
            isPaused = !isPaused;
        }
        
        thePauseButton.gameObject.SetActive(isPaused);
        thePausePanel.gameObject.SetActive(isPaused);
        // pausedText.gameObject.SetActive(isPaused);
        if (isPaused) {
            Time.timeScale = 0;
            // pausedText.text = "Paused";
            // Pause audio
            AudioListener.pause = true;
        } else {
            Time.timeScale = 1;
            // pausedText.text = "";
            // Resume audio
            AudioListener.pause = false;
        }

    }
}
