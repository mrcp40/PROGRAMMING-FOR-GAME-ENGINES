using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField]
    private Button _restart=null;
   
    void Start()
    {
        _restart.onClick.AddListener(OnButtonClick);
    }

    

    private void OnButtonClick()
    {
        SceneManager.LoadScene("Start",LoadSceneMode.Single);
    }
}
