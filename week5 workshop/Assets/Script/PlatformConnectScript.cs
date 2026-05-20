using UnityEngine;

public class PlatformConnectScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other != null&&other.gameObject!=null)
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.gameObject != null)
        {
            other.transform.parent = null;
        }
    }
}
