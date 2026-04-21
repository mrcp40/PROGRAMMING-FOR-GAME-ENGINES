using UnityEngine;

public class ConstantMovingLeftScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.0f;
    [SerializeField]
    private float boundaryX = 0.0f;



    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < boundaryX)
        {
            transform.position = new Vector3(-boundaryX, transform.position.y, transform.position.z);
        }
    }
}
