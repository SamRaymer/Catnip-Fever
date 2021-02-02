using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{

    public GameObject playMenu;
    public GameObject scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        
        // Hide scoreboard
        scoreBoard.gameObject.SetActive(false);

        // Show Menu
        playMenu.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
