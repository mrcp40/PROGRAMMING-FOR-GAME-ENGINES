using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyStrength : MonoBehaviour
{
    [SerializeField]
    private Button _buyStrength = null;
    [SerializeField]
    private TMP_Text _strengthCost = null;

    private int _clickCount = 0;
    private float _basicPrice = 2000;
    private void Start()
    {
        _buyStrength.onClick.AddListener(OnButtonClick);
        _clickCount = ShopManager.Instance.GetStrength() - 1;
    }

    private void Update()
    {
        _strengthCost.text = (_basicPrice + _clickCount * 400).ToString();
        if (_clickCount >= 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnButtonClick()
    {
        if (ShopManager.Instance.CheckStrengthLimit(_clickCount))
        {
            Debug.Log("check aprove");
            if (ShopManager.Instance.Buy(_basicPrice + _clickCount * 400))
            {
                _clickCount++;
                Debug.Log("paid");
                ShopManager.Instance.StrengthBought();
                return;
            }
        }

    }
}
