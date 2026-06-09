using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject!=null)
        {
            SceneManager.LoadScene(1);
        }
    }
}
