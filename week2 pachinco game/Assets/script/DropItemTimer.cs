using UnityEngine;
using System.Collections;

public class DropItemTimer : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 0.0f;

    private void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifeTime);

        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
