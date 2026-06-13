using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NewGame : MonoBehaviour
{
    [SerializeField]
    private Button _nextLevel = null;
    [SerializeField]
    private Data _data=null;
    void Start()
    {
        _nextLevel.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        _data.RestartGame();
        SceneManager.LoadScene("SampleScene");
        Scene sampleScene = SceneManager.GetSceneByName("SampleScene");
        SceneManager.SetActiveScene(sampleScene);
    }
}
