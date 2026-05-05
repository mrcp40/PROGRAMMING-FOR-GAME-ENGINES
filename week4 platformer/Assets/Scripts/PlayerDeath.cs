using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{


    [SerializeField]
    private Transform _respawPoint=null;
    [SerializeField]
    private bool _useStartingPoint = true;
    private Vector2 _startPoint;
    [SerializeField]
    private float _respawnTime = 2.0f;
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private Collider2D _collider;
    void Start()
    {
        _rigidBody=GetComponent<Rigidbody2D>();
        _animator=GetComponent<Animator>();
        _collider=GetComponent<Collider2D>();

        if( _useStartingPoint )
        {
            _startPoint = transform.position;
        }
        else if(_respawPoint != null )
        {
            _startPoint= _respawPoint.position;
        }
        else
        {
            _startPoint = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null && collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        _rigidBody.bodyType=RigidbodyType2D.Static;
        _animator.SetBool("Death",true);
        _animator.SetBool("Alive", false);
    }

      

    private void RestartLevel()
    {
        _rigidBody.bodyType = RigidbodyType2D.Dynamic;
        _collider.enabled=true;
        transform.position = _startPoint;
        _animator.SetBool("Alive", true);
        _animator.SetBool("Death", false);
        if (_rigidBody != null)
        {
            _rigidBody.linearVelocity = Vector2.zero;
        }
    }
}
