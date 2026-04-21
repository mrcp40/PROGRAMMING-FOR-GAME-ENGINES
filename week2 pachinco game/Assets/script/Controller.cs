using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject _dropItemPrefab = null;

    [SerializeField]
    private float _speed = 0.0f;

    [SerializeField]
    private Vector2 _maxRange = Vector2.zero;

    private Vector2 _startingPoint = Vector2.zero;

    private void Awake()
    {
        _startingPoint = transform.position;
    }
    void Update()
    {
        float facing = Input.GetAxisRaw("Horizontal");
        Vector3 endPos = transform.position;

        if (facing != 0)
        {
            if (facing == 1)
            {
                transform.localScale = new Vector3(2, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-2, transform.localScale.y, transform.localScale.z);

            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            endPos.y += _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            endPos.y -= _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            endPos.x -= _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            endPos.x += _speed * Time.deltaTime;
        }

        endPos.x = Mathf.Clamp(endPos.x, _startingPoint.x - _maxRange.x, _startingPoint.x + _maxRange.x);
        endPos.y = Mathf.Clamp(endPos.y, _startingPoint.y - _maxRange.y, _startingPoint.y + _maxRange.y);
        transform.position = endPos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newDropItem = Instantiate(_dropItemPrefab, transform.position, Quaternion.identity);
        }
    }
}
