using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticClass : MonoBehaviour
{

    static public float theScore = 0f;
    
    public void SetTheScore(float newScore) {
        theScore = newScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
