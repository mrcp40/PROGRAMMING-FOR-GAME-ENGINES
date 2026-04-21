using UnityEngine;

public class ConstantMovingScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.0f;
    [SerializeField]
    private float boundaryX = 0.0f;
    

    
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
        if (transform.position.x>boundaryX)
        {
            transform.position = new Vector3(-boundaryX, transform.position.y, transform.position.z);
        }
    }
}
