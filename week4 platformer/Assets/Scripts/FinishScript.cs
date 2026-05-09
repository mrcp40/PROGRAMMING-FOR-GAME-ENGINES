using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    private bool _player1Complete = false;
    private bool _player2Complete = false;
    private bool _levelComplete = false;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") && !_levelComplete)
        {
            _player1Complete = true;
        }
        if(collision.gameObject.CompareTag("Player2") && !_levelComplete)
        {
            _player2Complete = true;
        }
    }

    private void Update()
    {
        if (_player1Complete && _player2Complete && !_levelComplete)
        {
            _levelComplete = true;
            NextLevel();
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
