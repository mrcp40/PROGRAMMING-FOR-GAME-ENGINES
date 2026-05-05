using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    private bool _levelComplete = false;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2")) && !_levelComplete)
        {
            _levelComplete = true;
            Invoke("NextLevel", 2f);
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
