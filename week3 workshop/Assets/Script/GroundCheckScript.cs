using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{
    public bool _isGrounded { get { return _numCollision > 0; } }

    private int _numCollision = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ++_numCollision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        --_numCollision;
    }
}
