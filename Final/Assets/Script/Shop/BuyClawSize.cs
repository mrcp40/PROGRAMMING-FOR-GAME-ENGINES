using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyClawSize : MonoBehaviour
{
    [SerializeField]
    private Button _buyClawSize = null;
    [SerializeField]
    private TMP_Text _clawSizeCost = null;

    private int _clickCount = 0;
    private float _basicPrice = 2000;

    private void Awake()
    {
        _buyClawSize.onClick.AddListener(OnButtonClick);
    }

    private void Start()
    {
        _clickCount = ShopManager.Instance.GetClawSize() - 1;
        
    }

    private void Update()
    {
        _clawSizeCost.text = (_basicPrice + _clickCount * 400).ToString();
        if (_clickCount >= 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnButtonClick()
    {
        if (ShopManager.Instance.CheckClawSize(_clickCount))
        {
            if (ShopManager.Instance.Buy(_basicPrice + _clickCount * 400))
            {
                _clickCount++;
                ShopManager.Instance.ClawSizeBought();
                return;
            }
        }
    }
}
