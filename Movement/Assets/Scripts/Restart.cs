using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public Button btnActionButton;

    // Start is called before the first frame update
    void Start()
    {
        btnActionButton.onClick.AddListener(RestartGame);
    }

    void RestartGame() {
        Debug.Log("Starting Over");
        SceneManager.LoadScene("Level");
    }
}
