using TMPro;
using UnityEngine;

public class FishScript : MonoBehaviour
{

    [SerializeField]
    private float _speed = 0.0f;
    [SerializeField]
    private float _price = 0.0f;
    [SerializeField]
    private float _weight=0.0f;
    [SerializeField]
    private float _minX = 0.0f;
    [SerializeField]
    private float _maxX = 0.0f;
    private ClawScript _claw = null;
    private bool _isFree = true;

    private void Awake()
    {
        _maxX = FishManager.Instance.GetMaxX();
        _minX = FishManager.Instance.GetMinX();
    }

    private void Update()
    {
        if (!_isFree)
        {
            return;
        }
        if (transform.position.x <=_minX)
        {
            _speed = Mathf.Abs(_speed);
            _speed *= -1;
        }
        else if (transform.position.x >=_maxX)
        {
            _speed = Mathf.Abs(_speed);
            
        }


        transform.position = new Vector3(transform.position.x - _speed, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _claw = collision.GetComponent<ClawScript>();
        if (_claw != null)
        {
            if (!_claw.IsShooting())
            {
                return;
            }
            _claw.HitFish(this);
            transform.SetParent(collision.transform);
            _isFree = false;
        }
    }

    public float GetPrice()
    {
        return _price;
    }

    public float GetWeight()
    {
        return _weight;
    }
}
