using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _time=null;

    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }

    private float _gameTime = 0.0f;
    public static  float _endTime = 0.0f;
    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
            Initialize();
        
    }

    private void Initialize()
    {
        SaveManager.Initialize();
        SaveManager.Load();

        SaveManager.IncrementGamesPlayed();
        _gameTime = 0.0f;
    }

    private void Update()
    {
        _gameTime += Time.deltaTime;
        _time.text = "Time: " + _gameTime.ToString("F1");
    }

    public void GameOver()
    {
        _endTime = _gameTime;
        SaveManager.StoreBestTime(_gameTime);
        SaveManager.Save();
        SceneManager.LoadScene("End", LoadSceneMode.Single);
    }

    public float GetEndTime()
    {
        return _endTime;
    }
}
