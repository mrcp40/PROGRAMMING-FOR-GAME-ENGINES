using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class WanderAi : MonoBehaviour
{
    enum BehaviorState
    {
        Wander,
        Seek
    }

    public class WanderData
    {
        public float minUpdateTime = 10.0f;
        public float maxUpdateTime = 20.0f;
        public float moveRange = 5.0f;

        public float updateTime = 0.0f;
        public Vector3 centerPoint = Vector3.zero;
        public Vector3 currentTarget = Vector3.zero;
    }

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

    private NavMeshAgent _wanderAgent = null;
    private WanderData _wData = new WanderData();
    private SeekData _seekData = new SeekData();

    private void Awake()
    {
        _wanderAgent = GetComponent<NavMeshAgent>();

    }

    public void SetDestination(Vector3 destination)
    {
        _wanderAgent.SetDestination(destination);
    }

    private void Update()
    {
        DoWander();
    }
   
    private void StartWander()
    {
        WayPointScript waypoint = WanderWaypointManager.Instance.GetRandomWaypoint();
        _wData.currentTarget = waypoint.transform.position;
        _wData.updateTime = Random.Range(_wData.minUpdateTime, _wData.maxUpdateTime);
        SetDestination(_wData.currentTarget);
    }
    private void DoWander()
    {
        _wData.updateTime -= Time.deltaTime;
        if (_wData.updateTime <= 0.0f || Vector3.SqrMagnitude(transform.position - _wData.currentTarget) < 3.0f)
        {
            StartWander();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("collid");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
