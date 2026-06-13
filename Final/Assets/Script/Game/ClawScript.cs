using UnityEngine;
using UnityEngine.InputSystem;

public class ClawScript : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 0.0f;
    [SerializeField]
    private float _maxRotationAngle = 70.0f;
    [SerializeField]
    private float _clawSpeed = 0.0f;
    [SerializeField]
    private float _maxLength = 10.0f;
    [SerializeField]
    private GameObject _predicttion = null;

    private float _baseSpeed = 5.0f;
    private Rigidbody2D _rigidbody2D = null;
    private PlayerInput _playerInput = null;
    private InputAction _jumpAction = null;
    private bool _isShooting = false;
    private bool _isPulling = false;
    private float _length = 0.0f;
    private float _fishWeight = 1.0f;

    private float _currentAngle = 0.0f;
    private int _rotateDirection = 1;
    private Vector2 _position = Vector2.zero;
    private bool _enablePredict = false;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = new PlayerInput();
        _position = transform.position;
        _jumpAction = _playerInput.Player.Jump;
        _jumpAction.performed += OnJump;
        _predicttion.SetActive(false);
        _enablePredict = GameController.Instance.GetPrediction();
    }

    private void Start()
    {
        transform.localScale = transform.localScale * (1 + (GameController.Instance.GetClawSize() - 1) * 0.2f);
        if (_enablePredict)
        {
            _predicttion.SetActive(true);
        }
    }

    private void OnEnable()
    {
        _jumpAction.Enable();
    }

    private void OnDisable()
    {
        _jumpAction.Disable();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isShooting && !_isPulling)
        {
            _isShooting = true;
        }

        if (_isShooting && !_isPulling)
        {
            Shoot();
        }
        else if (!_isShooting && _isPulling)
        {
            Pull();
        }
        else
        {
            Swing();
        }

    }

    void Shoot()
    {
        if (!_isShooting)
        {
            return;
        }
        _clawSpeed = _baseSpeed;
        Vector2 direction = GetDirection();
        Vector2 velocity = direction.normalized * _clawSpeed * Time.deltaTime;
        transform.position += (Vector3)velocity;
        _length += _clawSpeed * Time.deltaTime;
        _predicttion.SetActive(false);
        if (_length >= _maxLength)
        {
            _isShooting = false;
            _isPulling = true;
            _length = _maxLength;
        }

    }

    void Pull()
    {
        if (!_isPulling)
        {
            return;
        }

        if (_length <= 0.0f)
        {
            _isPulling = false;
            _length = 0.0f;
            transform.position = _position;
            if (_enablePredict)
            {
                _predicttion.SetActive(true);
            }
            return;
        }
        _clawSpeed = SpeedWithFish();
        Vector2 direction = -GetDirection();
        Vector2 velocity = direction.normalized * _clawSpeed * Time.deltaTime;
        transform.position += (Vector3)velocity;
        _length -= _clawSpeed * Time.deltaTime;


    }

    void Swing()
    {
        _currentAngle += _rotateDirection * _rotationSpeed * Time.deltaTime;

        if (_currentAngle >= _maxRotationAngle)
        {
            _currentAngle = _maxRotationAngle;
            _rotateDirection = -1;
        }
        else if (_currentAngle <= -_maxRotationAngle)
        {
            _currentAngle = -_maxRotationAngle;
            _rotateDirection = 1;
        }

        transform.rotation = Quaternion.Euler(0, 0, -_currentAngle);
    }

    private void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (!_isShooting && !_isPulling)
        {
            _isShooting = true;
        }
    }
    Vector2 GetDirection()
    {
        return -transform.up;
    }


    public void HitFish(FishScript fish)
    {
        _fishWeight = fish.GetWeight();
        Hit();
    }
    public void Hit()
    {
        _isShooting = false;
        _isPulling = true;
    }
    public bool IsShooting()
    {
        return _isShooting;
    }

    private float SpeedWithFish()
    {
        float str = PlayerData.Instance.GetStrength();
        return (str / _fishWeight) * _baseSpeed;
    }
}
