using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoStartGameTruck : MonoBehaviour
{

    public GameObject truck;
    public GameObject timerBox;
    public GameObject scoreBox;
    public GameObject controllyThuing;
    public GameObject me;
    public Button btnStart;

    // Start is called before the first frame update
    void Start()
    {
        btnStart.onClick.AddListener(DoStart);
        scoreBox.gameObject.SetActive(false);
        timerBox.gameObject.SetActive(false);
        me.gameObject.SetActive(true);

    }

    void DoStart() {
        controllyThuing.GetComponent<GameTimer>().timerIsRunning = true;
        me.gameObject.SetActive(false);
        scoreBox.gameObject.SetActive(true);
        timerBox.gameObject.SetActive(true);
        Instantiate(truck, new Vector3(0,0,0), new Quaternion(0f, 0f, 0f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
