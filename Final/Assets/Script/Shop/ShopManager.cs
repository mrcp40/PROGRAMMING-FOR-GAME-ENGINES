using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private Data _data;
    [SerializeField]
    private TMP_Text _currentGold = null;
    
    
    
    

    private static ShopManager instance;
    public static ShopManager Instance { get { return instance; } }

    private int _maxStrength = 5;
    private int _maxClawSize = 5;
    private int _maxClawCount = 3;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        UpdateText();
    }
    public bool Buy(float amount)
    {
        if (_data._gold < amount)
        {
            return false;
        }
        _data._gold -= amount;
        return true;
    }

    public bool CheckStrengthLimit(int amount)
    {
        return amount <= _maxStrength;
    }

    public bool CheckClawSize(int amount)
    {
        return amount <= _maxClawSize;
    }

    public bool CheckClawCount(int amount)
    {
        return amount <= _maxClawCount;
    }

    public bool CheckPrediction()
    {
        return _data._prediction;
    }

    public void StrengthBought()
    {
        _data._strength++;
    }
    public int GetStrength()
    {
        return _data._strength;
    }
    public void ClawSizeBought()
    {
        _data._clawSize++;
    }

    public int GetClawSize()
    {
        return _data._clawSize;
    }
    public void ClawCountBought()
    {
        _data._clawCount++;
    }

    public int GetClawCount()
    {
        return _data._clawCount;
    }
    public void PredictionBought()
    {
        _data._prediction = true;
    }

    private void UpdateText()
    {
        _currentGold.text="Current Gold:"+_data._gold.ToString();
    }

    
}
