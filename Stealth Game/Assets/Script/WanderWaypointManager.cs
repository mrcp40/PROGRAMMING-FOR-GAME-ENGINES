using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WanderWaypointManager : MonoBehaviour
{
    [SerializeField]
    private List<WayPointScript> _wayPoints = new List<WayPointScript>();

    static WanderWaypointManager instance = null;
    public static WanderWaypointManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (_wayPoints.Count == 0)
            {
                _wayPoints = transform.GetComponentsInChildren<WayPointScript>().ToList();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public WayPointScript GetWayPoint(int index)
    {
        if (index < _wayPoints.Count)
        {
            return _wayPoints[index];
        }
        return null;
    }

    public WayPointScript GetRandomWaypoint()
    {
        if (_wayPoints.Count == 0)
        {
            return null;
        }
        int randIndex = Random.Range(0, _wayPoints.Count);
        return _wayPoints[randIndex];
    }

    public WayPointScript GetClosedWaypoint(Vector3 position)
    {
        if (_wayPoints.Count == 0)
        {
            return null;
        }

        WayPointScript closestWypoint = null;
        float closestDistanceSq = float.MaxValue;
        foreach (WayPointScript waypoint in _wayPoints)
        {
            float distSq = Vector3.SqrMagnitude(waypoint.transform.position - position);
            if (distSq > closestDistanceSq)
            {
                closestDistanceSq = distSq;
                closestWypoint = waypoint;
            }
        }
        return closestWypoint;
    }

    public WayPointScript GetRandomWaypointInRange(Vector3 position, float range)
    {
        float distSq = range * range;
        List<WayPointScript> inRangeWaypoint = new List<WayPointScript>();
        foreach (WayPointScript waypoint in _wayPoints)
        {
            if (Vector3.SqrMagnitude(waypoint.transform.position - position) <= range)
            {
                inRangeWaypoint.Add(waypoint);
            }
        }
        if (inRangeWaypoint.Count > 0)
        {
            int randIndex = Random.Range(0, inRangeWaypoint.Count);
            return inRangeWaypoint[randIndex];
        }
        return null;
    }
}
