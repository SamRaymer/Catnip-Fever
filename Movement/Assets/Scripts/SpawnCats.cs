using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCats : MonoBehaviour
{
    
    public GameObject prefabCat;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabCat, new Vector3(0,0,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
