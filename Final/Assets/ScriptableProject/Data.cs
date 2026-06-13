using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Data")]
public class Data : ScriptableObject
{
    public float _gold = 0.0f;
    public int _strength = 1;
    public int _clawSize = 1;
    public int _clawCount = 1;
    public bool _prediction=false;

    public void RestartGame()
    {
        _gold=0.0f;
        _strength = 1;
        _clawSize = 1;
        _clawCount=1;
        _prediction= false;
    }
}
