using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public int catsReturned = 0;
    public Text theScoreText;
    public int oldScore = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        StaticClass.theScore = 0;
        theScoreText.text = "SCORE: " + StaticClass.theScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (catsReturned != oldScore) {
            oldScore = catsReturned;
            theScoreText.text = "SCORE: " + catsReturned;

        }
    }

    public void catWasReturned(int value) {
        catsReturned += value;
        StaticClass.theScore = catsReturned;
        theScoreText.text = "SCORE: " + catsReturned;
        Debug.Log("Cat");

        // Debug.Log(string.Format("Cats: {0}", catsReturned));
    }
}
