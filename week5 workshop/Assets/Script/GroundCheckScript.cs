using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{
    private int _collisionCount = 0;

    public bool IsGround { get { return _collisionCount > 0; } }

    private void OnTriggerEnter(Collider other)
    {
        ++_collisionCount;
    }

    private void OnTriggerExit(Collider other)
    {
        --_collisionCount;
    }
}
