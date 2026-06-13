using TMPro;
using UnityEngine;



public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private Data _data;
    private int _strength;
    private static int _maxStrength=6;

    private float _gold = 0.0f;

    private static PlayerData instance;
    public static PlayerData Instance {  get { return instance; } }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _strength = _data._strength;
        _gold = _data._gold;
    }

    public void AddStrength()
    {
        _strength++;
        _data._strength = _strength;
    }
    public int GetStrength()
    {
        return _strength;
    }
    public bool CheckStrength()
    {
        return _strength >= _maxStrength;
    }

    public float GetGold()
    {
        return _gold;
    }
    public void AddGold(float g)
    {
        _gold += g;
        _data._gold = _gold;
    }
}
