using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button btnQuit;
    public GameObject playMenu;
    public GameObject scoreBoard;
    public GameObject theTimerObject;

    
    // Start is called before the first frame update
    void Start()
    {
        btnQuit.onClick.AddListener(DoStartGame);
        Time.timeScale = 0;
    }

    void DoStartGame() {
        playMenu.gameObject.SetActive(false);
        scoreBoard.gameObject.SetActive(true);

        Time.timeScale = 1;
        theTimerObject.GetComponent<GameTimer>().timerIsRunning = true;


    }
    // Update is called once per frame
    void Update()
    {
        // theTimerObject.GetComponent<PauseGame>().isPaused = true;
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }
}
