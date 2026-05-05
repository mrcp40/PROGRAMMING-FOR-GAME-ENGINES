using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _melonScoreText=null;
    [SerializeField]
    private TMP_Text _cherryScoreText=null;

    private int _melonScore = 0;
    private int _cherryScore = 0;

    private static GameManagerScript instance = null;
    public static GameManagerScript Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            UpdateMScore();
        }
        else
            Destroy(gameObject);
    }

    public void AddMScore(int amount)
    {
        _melonScore += amount;
        UpdateMScore();
        UpdateCScore();
    }

    public void AddCScore(int amount)
    {
        _cherryScore += amount;
        UpdateCScore();
    }

    private void UpdateMScore()
    {
        _melonScoreText.text = "Melon: " + _melonScore.ToString();
    }

    private void UpdateCScore()
    {
        _cherryScoreText.text = "Cherry: " + _cherryScore.ToString();
    }
}
