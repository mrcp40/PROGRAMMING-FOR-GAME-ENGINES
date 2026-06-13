using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyPrediction : MonoBehaviour
{
    [SerializeField]
    private Button _buyPrediction = null;
    [SerializeField]
    private TMP_Text _predictionCost = null;

    private int _clickCount = 0;
    private float _basicPrice = 10000;
    private void Start()
    {
        _buyPrediction.onClick.AddListener(OnButtonClick);
    }

    private void Update()
    {
        _predictionCost.text = _basicPrice.ToString();
        if (_clickCount >= 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnButtonClick()
    {
        if (!ShopManager.Instance.CheckPrediction())
        {
            if (ShopManager.Instance.Buy(_basicPrice))
            {
                _clickCount++;
                ShopManager.Instance.PredictionBought();
                return;
            }
        }

    }
}
