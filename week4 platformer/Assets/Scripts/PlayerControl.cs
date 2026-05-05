using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private Animator _animator = null;
    [SerializeField]
    private float _moveSpeed = 5.0f;
    [SerializeField]
    private float _jumpSpeed = 3.0f;
    [SerializeField]
    private GroundCheck _groundCheck = null;


    private float _desiredHorizontalSpeed = 0.0f;
    private Rigidbody2D _rigidBody = null;

    private PlayerInput _playerInput=null;
    private InputAction _moveAction=null;
    private InputAction _jumpAction=null;

    private bool _isJump = false;
    private bool _isFall = false;
    private float _facingDirection = 0.0f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerInput = new PlayerInput();
        _moveAction=_playerInput.Player.Move;
        _jumpAction=_playerInput.Player.Jump;
        _jumpAction.performed += OnJump;
    }
    private void OnEnable()
    {
        _moveAction.Enable();
        _jumpAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _jumpAction.Disable();
    }

    void Update()
    {
        _desiredHorizontalSpeed = _moveAction.ReadValue<Vector2>().x * _moveSpeed;
        if (_rigidBody.linearVelocityY < -0.1f)
        {
            _isFall = true;
            _isJump = false;
        }
        else if (_isFall && _groundCheck._isGrounded && _rigidBody.linearVelocityY < 0.1f)
        {

            _isFall = false;
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.linearVelocityX = _desiredHorizontalSpeed;

        _animator.SetFloat("Speed", Mathf.Abs(_desiredHorizontalSpeed));
        if (Mathf.Abs(_desiredHorizontalSpeed) > 0.1)
        {
            _facingDirection = _desiredHorizontalSpeed > 0.0f ? 0.0f : 1.0f;
        }

        _animator.SetFloat("Speed", Mathf.Abs(_desiredHorizontalSpeed));
        _animator.SetFloat("Direction", _facingDirection);
        _animator.SetBool("Jump", _isJump);
        _animator.SetBool("Fall", _isFall);
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (_groundCheck._isGrounded&& _rigidBody.linearVelocityY < 0.1f)
        {
            _rigidBody.linearVelocityY = _jumpSpeed;
            _isJump = true;
        }
    }

}
