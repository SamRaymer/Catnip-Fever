using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = "High Score: " + StaticClass.theScore;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Text>().text = "High Score: " + StaticClass.theScore;
        
    }
}
