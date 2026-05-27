
using UnityEngine;
using UnityEngine.AI;

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
        public  float maxSearchTime = 5.0f;
        public  float searchTime = 0.0f;
        public Vector3 targetPosition = Vector3.zero;
    }

    [SerializeField]
    private GameObject _targetObject = null;
    [SerializeField]
    private float _viewDistance = 10.0f;

    private NavMeshAgent _agent = null;
    private BehaviorState _state = BehaviorState.Wander;
    private WanderData _wanderData = new WanderData();
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
    private bool CanSeekTargert()
    {
        if(_targetObject == null)
        {
            Vector3 direction=_targetObject.transform.position-transform.position;
            direction.Normalize();
            RaycastHit hitInfo;
            if(Physics.Raycast(transform.position, direction, out hitInfo,_viewDistance))
            {
                if(hitInfo.collider!=null)
                {
                    if(hitInfo.collider.gameObject==_targetObject)
                    {
                        Debug.DrawLine(transform.position,hitInfo.point,Color.green,1.0f);
                        return true;
                    }
                }
                Debug.DrawLine(transform.position, hitInfo.point,Color.red,1.0f);
            }
            else
            {
                Debug.DrawLine(transform.position,transform.position+direction*_viewDistance,Color.red,1.0f);
            }
        }
        return false;
    }
    private void StartWander()
    {
        WayPointScript waypoint = WayPointManager.Instance.GetRandomWaypoint();
        _wanderData.currentTarget = waypoint.transform.position;
        _wanderData.updateTime = Random.Range(_wanderData.minUpdateTime, _wanderData.maxUpdateTime);
        SetDestination(_wanderData.currentTarget);
        _state = BehaviorState.Wander;
    }
    private void DoWander()
    {
        if(CanSeekTargert())
        {
            StartSeek();
            return;
        }
        _wanderData.updateTime-=Time .deltaTime;
        if(_wanderData.updateTime<=0.0f||Vector3.SqrMagnitude(transform.position-_wanderData.currentTarget)<3.0f)
        {
            StartWander();
        }
    }


    private void StartSeek()
    {
        _seekData.targetPosition=_targetObject.transform.position;
        SetDestination(_seekData.targetPosition);
        _state= BehaviorState.Seek;
    }
    private void DoSeek()
    {
        if(!CanSeekTargert())
        {
            _seekData.searchTime-=Time .deltaTime;
            if(_seekData.searchTime<=0.0f)
            {
                StartWander();
            }
        }
        else
        {
            _seekData.searchTime=_seekData.maxSearchTime;
            _seekData.targetPosition= _targetObject.transform.position;
        }
        SetDestination(_seekData.targetPosition);
    }
}
