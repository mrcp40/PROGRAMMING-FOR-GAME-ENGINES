using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private bool _disableOnTrigger = false;

    private Collider _collider = null;


    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        CheckPointManager.Instance.SaveCheckPoint(this);
        if (_disableOnTrigger)
        {
            this._collider.enabled = false;
            transform.localScale = Vector3.one * 0.5f;
        }
    }
}
