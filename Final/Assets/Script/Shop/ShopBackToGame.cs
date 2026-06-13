using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopBackToGame : MonoBehaviour
{
    [SerializeField]
    private Button _nextLevel=null;

    void Start()
    {
        _nextLevel.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
    }
}
