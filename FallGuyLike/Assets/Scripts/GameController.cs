using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }

    private float _gameTime = 0.0f;
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
    }

    public void GameOver()
    {
        SaveManager.StoreBestTime(_gameTime);
        SaveManager.Save();
    }
}
