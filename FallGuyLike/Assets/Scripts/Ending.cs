using TMPro;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _time=null;
    
    private void Awake()
    {
        _time.text = "Time: " + GameController._endTime.ToString("F1");
    }
}
