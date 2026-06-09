using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AiAgent : MonoBehaviour
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
        public float maxSearchTime = 2.0f;
        public float searchTime = 0.0f;
        public Vector3 targetPosition = Vector3.zero;
    }

    [SerializeField]
    private GameObject _targetObject = null;
    [SerializeField]
    private float _viewDistance = 10.0f;
    [SerializeField]
    private GameObject _player = null;

    private NavMeshAgent _agent = null;
    private BehaviorState _state = BehaviorState.Wander;
    private WanderData _wanderData = new WanderData();
    private SeekData _seekData = new SeekData();

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

    }
    private void Start()
    {
        StartWander();
    }
    public void SetDestination(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }

    private void Update()
    {
        if (CanSeekPlayer())
        {
            StartSeekPlayer();
        }

        switch (_state)
        {
            case BehaviorState.Wander:
                DoWander(); break;
            case BehaviorState.Seek:
                DoSeek(); break;
            default:
                break;
        }

    }
    
    private bool CanSeekPlayer()
    {
        Vector3 origin = transform.position + Vector3.up * 1.5f;
        Vector3 target = _player.transform.position + Vector3.up * 1.0f;
        Vector3 direction = (target - origin).normalized;
        RaycastHit hitInfo;

        int mask = LayerMask.GetMask("Player");
        if (Physics.Raycast(origin, direction, out hitInfo, _viewDistance,mask))
        {
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    Debug.DrawLine(transform.position, hitInfo.point, Color.green, 1.0f);
                    return true;
                }
                return false;
            }
            Debug.DrawLine(transform.position, hitInfo.point, Color.red, 1.0f);
            return false;
        }
        else
        {
            Debug.DrawLine(origin, transform.position + direction * _viewDistance, Color.red, 1.0f);
            return false;
        }

    }
    private void StartWander()
    {
        WayPointScript waypoint = WayPointManger.Instance.GetRandomWaypoint();
        _wanderData.currentTarget = waypoint.transform.position;
        _wanderData.updateTime = Random.Range(_wanderData.minUpdateTime, _wanderData.maxUpdateTime);
        SetDestination(_wanderData.currentTarget);
        _state = BehaviorState.Wander;
    }
    private void DoWander()
    {
        if (CanSeekPlayer())
        {
            StartSeekPlayer();
            return;
        }
        _wanderData.updateTime -= Time.deltaTime;
        if (_wanderData.updateTime <= 0.0f || Vector3.SqrMagnitude(transform.position - _wanderData.currentTarget) < 3.0f)
        {
            StartWander();
        }
    }

    private void StartSeekPlayer()
    {
        _seekData.targetPosition = _player.transform.position;

        _seekData.searchTime = _seekData.maxSearchTime;
        SetDestination(_seekData.targetPosition);
        _state = BehaviorState.Seek;
    }
    private void DoSeek()
    {
        if (!CanSeekPlayer())
        {
            _seekData.searchTime -= Time.deltaTime;
            if (_seekData.searchTime <= 0.0f)
            {
                StartWander();
            }
        }
        else
        {
            _seekData.searchTime = _seekData.maxSearchTime;
            _seekData.targetPosition = _player.transform.position;
        }
        SetDestination(_seekData.targetPosition);
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
