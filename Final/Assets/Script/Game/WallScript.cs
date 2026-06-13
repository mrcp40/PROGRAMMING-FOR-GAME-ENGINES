using UnityEngine;

public class WallScript : MonoBehaviour
{
    private ClawScript _claw=null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("≈ˆµΩ¡À: " + collision.name);
        _claw = collision.GetComponent<ClawScript>();
        if (_claw != null)
        {
            Debug.Log("’“µΩ ClawScript");
            _claw.Hit();
        }
    }
}
