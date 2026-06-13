using UnityEngine;

public class KillFish : MonoBehaviour
{
    private FishScript _fish=null;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        _fish=collision.GetComponent<FishScript>();
        if ( _fish != null )
        {
            GameController.Instance.GetGold(_fish.GetPrice());
            Debug.Log("Åöµ½ÁË: " + collision.name);
            FishManager.Instance.RemoveFish(collision.gameObject);
            Destroy(collision.gameObject);
        }
        return;
    }
}
