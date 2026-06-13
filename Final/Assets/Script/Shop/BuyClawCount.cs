using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyClawCount : MonoBehaviour
{
    [SerializeField]
    private Button _buyClawCount = null;
    [SerializeField]
    private TMP_Text _clawCountCost = null;

    private int _clickCount = 0;
    private float _basicPrice = 2000;
    private void Start()
    {
        _buyClawCount.onClick.AddListener(OnButtonClick);
        _clickCount = ShopManager.Instance.GetClawCount() - 1;
    }

    private void Update()
    {
        _clawCountCost.text = (_basicPrice + _clickCount * 400).ToString();
        if (_clickCount >= 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnButtonClick()
    {
        if (ShopManager.Instance.CheckClawCount(_clickCount))
        {
            if (ShopManager.Instance.Buy(_basicPrice + _clickCount * 400))
            {
                _clickCount++;
                ShopManager.Instance.ClawCountBought();
                return;
            }
        }

    }
}
