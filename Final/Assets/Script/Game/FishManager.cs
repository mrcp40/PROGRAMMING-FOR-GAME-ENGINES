using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    [SerializeField]
    private int _fishCount = 3;

    private static FishManager _instance=null;
    public static FishManager Instance {  get { return _instance; } }
    private List<GameObject> _activeFishes = new List<GameObject>();


    private float _limit = 8;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        GameObject[] allFishes = Resources.LoadAll<GameObject>("Prefabs");

        if (allFishes == null || allFishes.Length == 0)
        {
            Debug.Log("Î´Ñ¡ÖÐPrefab");
            return;
        }
        for (int i = 0; i < _fishCount; i++)
        {
            int randomIndex = Random.Range(0, allFishes.Length);
            GameObject prefab = allFishes[randomIndex];
            Vector2 position = new Vector2(Random.Range(-5.5f, 5.5f), Random.Range(-3.5f, 1.0f));
            GameObject fishObject = Instantiate(prefab, position, Quaternion.identity);
            _activeFishes.Add(fishObject);
        }


    }
    private void Update()
    {
        if(_activeFishes == null|| _activeFishes.Count==0)
        {
            GameController.Instance.EnterShop();
        }
    }
    public float GetMaxX()
    {
        return Random.Range(_limit,0);
    }

    public float GetMinX()
    {
        return Random.Range( -_limit,0);
    }

    public void RemoveFish(GameObject fish)
    {
        if (_activeFishes.Contains(fish))
        {
            _activeFishes.Remove(fish);
        }
    }
}
