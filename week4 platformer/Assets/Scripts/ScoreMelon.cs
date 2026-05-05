using UnityEngine;

public class ScoreMelon : MonoBehaviour
{
    [SerializeField]
    private int _score = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null && collision.tag == "Player1")
        {
            GameManagerScript.Instance.AddMScore(_score);
            Destroy(gameObject);
        }
    }
}
