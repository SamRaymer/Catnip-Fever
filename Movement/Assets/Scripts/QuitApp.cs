using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitApp : MonoBehaviour
{
    
    public Button btnQuit;

    // Start is called before the first frame update
    void Start() {
        btnQuit.onClick.AddListener(DoExitGame);
    }

    void DoExitGame() {
        Debug.Log("I Quit");
        Application.Quit();
    }
    
    // Update is called once per frame
    void Update() {
        
    }

}
