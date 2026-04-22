using UnityEngine;
using System.Collections;

public class PickUpsScript : MonoBehaviour
{
    [SerializeField]
    private int _score = 10;
    [SerializeField]
    private float respawnDelay = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null && collision.tag == "DropItem")
        {
            GameManager.Instance.AddScore(_score);
            StartCoroutine(DisableAndRespawn());
        }
    }
    private IEnumerator DisableAndRespawn()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }

}
