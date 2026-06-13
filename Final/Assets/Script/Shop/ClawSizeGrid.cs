using System.Collections.Generic;
using UnityEngine;

public class ClawSizeGrid : MonoBehaviour
{

    [SerializeField]
    private GameObject _light = null;
    [SerializeField]
    private GameObject _dark = null;

    private void Awake()
    {
        _light.SetActive(false);
        _dark.SetActive(true);
    }

    private void Update()
    {
        TurnOn(GridManager.Instance.TurnClawSizeGrid(this));
    }

    private void TurnOn(bool on)
    {
        if (on)
        {
            _light.SetActive(true);
            _dark.SetActive(false);
        }
        else
        {
            _light.SetActive(false);
            _dark.SetActive(true);
        }
    }
}
