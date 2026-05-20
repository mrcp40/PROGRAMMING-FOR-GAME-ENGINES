using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    static CheckPointManager _instance = null;

    static public CheckPointManager Instance { get { return _instance; } }

    private CheckPoint _isLastCheckPoint = null;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveCheckPoint(CheckPoint checkPoint)
    {
        _isLastCheckPoint = checkPoint;
    }

    public CheckPoint GetSavedCheckPoint()
    {
        return _isLastCheckPoint;
    }
}

