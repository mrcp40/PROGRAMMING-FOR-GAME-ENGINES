using UnityEngine;

public class VerticalMovingTrapScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.0f;
    [SerializeField]
    private float _minimumY = 0.0f;
    [SerializeField]
    private float _maximumY = 0.0f;



    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if (transform.position.y < _minimumY || transform.position.y > _maximumY)
        {
            _speed *= -1;
        }

    }
}
