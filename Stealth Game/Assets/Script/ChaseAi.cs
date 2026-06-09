using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ChaseAi : MonoBehaviour
{
    public class SeekData
    {
        public float maxSearchTime = 5.0f;
        public float searchTime = 0.0f;
        public Vector3 targetPosition = Vector3.zero;
    }

    [SerializeField]
    private GameObject _targetObject = null;
    [SerializeField]
    private float _viewDistance = 10.0f;

    private NavMeshAgent _agent = null;
    private SeekData _seekData = new SeekData();

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

    }

    public void SetDestination(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }

    private void Update()
    {
        DoSeek();
    }

   

    private void DoSeek()
    {
        
        _seekData.searchTime = _seekData.maxSearchTime;
        _seekData.targetPosition = _targetObject.transform.position;
        
        SetDestination(_seekData.targetPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player" )
        {
            Debug.Log("collid");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
