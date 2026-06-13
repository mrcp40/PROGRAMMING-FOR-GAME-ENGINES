using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private List<StrengthGridScript> _strengthGrids = new List<StrengthGridScript>();
    [SerializeField]
    private List<ClawSizeGrid> _clawSizeGrids = new List<ClawSizeGrid>();
    [SerializeField]
    private List<ClawCountScript> _clawCountGrids= new List<ClawCountScript>();
    [SerializeField]
    private Data _data;

    private static GridManager instance;
    public static GridManager Instance { get { return instance; } }

    private int _strengthIndex = -1;
    private int _clawSizeIndex = -1;
    private int _clawCountIndex = -1;
    private bool _prediction=false;

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

    private void Start()
    {
        _strengthIndex = _data._strength - 2;
        _clawSizeIndex= _data._clawSize - 2;
        _clawCountIndex= _data._clawCount - 2;
        _prediction = _data._prediction;
    }

    void Update()
    {
        _strengthIndex = _data._strength - 2;
        _clawSizeIndex = _data._clawSize - 2;
        _clawCountIndex = _data._clawCount - 2;
        _prediction = _data._prediction;
    }


    public bool TurnStrengthGrid(StrengthGridScript grid)
    {
        if(_strengthGrids==null||_strengthGrids.Count==0)
        {
            return false;
        }
       if(_strengthGrids.IndexOf(grid) <= _strengthIndex)
        {
            return true;
        }
       return false;
    }

    public bool TurnClawSizeGrid(ClawSizeGrid grid)
    {
        if (_clawSizeGrids == null || _clawSizeGrids.Count == 0)
        {
            return false;
        }
        if (_clawSizeGrids.IndexOf(grid) <= _clawSizeIndex)
        {
            return true;
        }
        return false;
    }

    public bool TurnClawCountGrid(ClawCountScript grid)
    {
        if (_clawCountGrids == null || _clawCountGrids.Count == 0)
        {
            return false;
        }
        if (_clawCountGrids.IndexOf(grid) <= _clawCountIndex)
        {
            return true;
        }
        return false;
    }

    public bool TurnPredictionGrid(PredictionGrid grid)
    {
        if(_prediction)
        {
            return true;
        }
        return false;
    }
}
