using UnityEngine;

public class EndScript : MonoBehaviour
{
    private bool _isTrigger=false;
    private void OnTriggerEnter(Collider other)
    {
        if(_isTrigger)
        {
            return;
        }
        GameController.Instance.GameOver();
    }
}
