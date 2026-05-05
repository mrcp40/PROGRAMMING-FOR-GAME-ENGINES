using UnityEngine;

public class ScoreCherry : MonoBehaviour
{
    [SerializeField]
    private int _score = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null && collision.tag == "Player2")
        {
            GameManagerScript.Instance.AddCScore(_score);
            Destroy(gameObject);
        }
    }
}
