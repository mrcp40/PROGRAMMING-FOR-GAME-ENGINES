using UnityEngine;

public class HorizontalMovingTrapScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.0f;
    [SerializeField]
    private float _minimumX = 0.0f;
    [SerializeField]
    private float _maximumX = 0.0f;



    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        if (transform.position.x < _minimumX || transform.position.x > _maximumX)
        {
            _speed *= -1;
        }

    }
}
