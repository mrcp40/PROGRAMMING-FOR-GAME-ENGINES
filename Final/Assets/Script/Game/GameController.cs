using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text=null;
    [SerializeField]
    private TMP_Text _time=null;
    [SerializeField]
    private Data _data=null;

    [SerializeField]
    private List<GameObject> _claws=new List<GameObject>();

    private float _levelTime = 60;

    private static GameController _instance;
    public static GameController Instance {  get { return _instance; } }
    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
            UpdateGold();
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    private void Start()
    {
        for (int i = 0; i < _claws.Count; i++)
        {
            Debug.Log("½ûÓÃ×¦×Ó " + i + ": " + _claws[i].name);
            _claws[i].gameObject.SetActive(false);
        }

        int clawAmount=GetClawCount();
        Debug.Log(clawAmount.ToString());
        for (int i = 0; i < clawAmount; i++)
        {
            _claws[i].gameObject.SetActive(true);
        }

    }
    void Update()
    {
        if (_time == null) Debug.LogError("_time is null!");
        _levelTime-= Time.deltaTime;
        if (_levelTime<=0)
        {
            End();
            return;
        }
        UpdateTime();
        UpdateGold();
    }

    public void GetGold(float g)
    {
        PlayerData.Instance.AddGold(g);
        UpdateGold();
    }

    private void UpdateTime()
    {
        _time.text = "Time: " + Mathf.Max(0, _levelTime).ToString("F0") + "s";
    }
    private void UpdateGold()
    {
        _text.text = "Gold: " + PlayerData.Instance.GetGold().ToString();
    }

    public void End()
    {
        SceneManager.LoadScene("End",LoadSceneMode.Single);
    }

    public void EnterShop()
    {
        SceneManager.LoadScene("Shop",LoadSceneMode.Single);
    }

    public int GetClawSize()
    {
        return _data._clawSize;
    }

    private int GetClawCount()
    {
        return _data._clawCount;
    }

    public bool GetPrediction()
    {
        return _data._prediction;
    }
}
