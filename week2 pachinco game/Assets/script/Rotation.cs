using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.0f;
    void Update()
    {
        transform.Rotate(0,0, speed * Time.deltaTime);
    }
}
