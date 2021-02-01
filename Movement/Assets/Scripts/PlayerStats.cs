using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int catsReturned = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(StaticClass.theScore);
        StaticClass.theScore = catsReturned;
    }

    public void catWasReturned(int value) {
        catsReturned += value;
        Debug.Log(string.Format("Cats: {0}", catsReturned));
    }
}
