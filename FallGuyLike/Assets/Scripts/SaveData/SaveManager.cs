using System.IO;
using UnityEngine;

public class SaveManager
{
    private static GameData _gameData = null;
    public static bool IsInitialized()
    {
        return _gameData != null;
    }

    public static void Initialize()
    {
        if (_gameData == null)
        {
            _gameData = new GameData();
            CheckPoint checkPoint = CheckPointManager.Instance.GetSavedCheckPoint();
            if (checkPoint != null)
            {
                _gameData.LastCheckpointLocation = checkPoint.transform.position;
            }
        }
    }
    private static string GetFullFilePath()
    {
        return Application.dataPath+"/game.json" ;
    }

    public static void Save()
    {
        string data=JsonUtility.ToJson(_gameData,true);
        File.WriteAllText(GetFullFilePath(), data);
    }

    public static void Load()
    {
        string filePath = GetFullFilePath();
        Debug.Log("loading file:"+filePath);
        if(File.Exists(filePath))
        {
            string data=File.ReadAllText(filePath);
            _gameData=JsonUtility.FromJson<GameData>(data);
        }
    }

    public static GameData GetGameData()
    {
        return _gameData;
    }

    public static void StoreBestTime(float time)
    {
        if(_gameData.BestTime<=0.0f||time<_gameData.BestTime)
        {
            _gameData.BestTime = time;
        }
    }

    public static void IncrementGamesPlayed(int count=1)
    {
        _gameData.GamePlayed += count;
    }
    public static void SetLastSavedCheckpoint(Vector3 position)
    {
        _gameData.LastCheckpointLocation= position;
    }
}