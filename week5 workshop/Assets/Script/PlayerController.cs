using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform _shoulderTransform = null;
    [SerializeField]
    private GroundCheckScript _groundCheck=null;
    [SerializeField]
    private float _speed = 0.0f;
    [SerializeField]
    private float _turnSpeed = 0.0f;
    [SerializeField]
    private float _jumpSpeed = 0.0f;
    [SerializeField]
    private bool _invertY = false;
    [SerializeField]
    private float _maxPitchAngle = 70.0f;
    [SerializeField]
    private float _minPitchAngle = -70.0f;


    private Rigidbody _rigidbody = null;
    private PlayerInput _playerInput = null;
    private InputAction _moveAction = null;
    private InputAction _lookAction = null;
    private InputAction _jumpAction = null;
    private Vector3 _moveVelocity = Vector3.zero;
    private Vector3 _moveRotation = Vector3.zero;
    private float _pitchRotation = 0.0f;
    private float _initialFram = 2.0f;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = new PlayerInput();
        _moveAction = _playerInput.Player.Move;
        _lookAction = _playerInput.Player.Look;
        _jumpAction = _playerInput.Player.Jump;

        _jumpAction.performed += OnJump;

        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        _moveAction.Enable();
        _lookAction.Enable();
        _jumpAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _lookAction.Disable();
        _jumpAction.Disable();
    }
    void Update()
    {
        if (_initialFram>0)
        {
            _initialFram--;
            return;
        }
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        Vector2 lookInput = _lookAction.ReadValue<Vector2>();

        Vector3 fwd = transform.forward;
        Vector3 right = transform.right;
        fwd.y = 0;
        right.y = 0;
        _moveVelocity = ((fwd * moveInput.y) + (right * moveInput.x)) * _speed;

        _moveRotation.y = lookInput.x * _turnSpeed;

        if (_invertY)
        {
            lookInput.y *= -1;
        }
        _pitchRotation = Mathf.Clamp(_pitchRotation + lookInput.y, _minPitchAngle, _maxPitchAngle);
    }

    private void FixedUpdate()
    {
        _moveVelocity.y = _rigidbody.linearVelocity.y;
        _rigidbody.linearVelocity = _moveVelocity;
        _rigidbody.angularVelocity = _moveRotation;
        _shoulderTransform.localRotation = Quaternion.Euler(_pitchRotation, 0.0f, 0.0f);
    }

    private void OnJump(InputAction.CallbackContext callbackContext )
    {
        if(_rigidbody.linearVelocity.y<0.1f&&_groundCheck.IsGround)
        {
            Vector3 jumpVelocity=_rigidbody.linearVelocity;
            jumpVelocity.y = _jumpSpeed;
            _rigidbody.linearVelocity= jumpVelocity;
        }
    }
}
