using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Rabbit : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _minimumIdleTime;
    [SerializeField] private float _maximumIdleTime;

    private NavMeshAgent _agent;
    private Transform _currentWaypoint;
    private RabbitState _state;
    private float _idleTime;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _state = RabbitState.Idle;
        _idleTime = Random.Range(_minimumIdleTime, _maximumIdleTime);
        _currentWaypoint = GetRandomPoint();

        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (_state == RabbitState.Idle )
        {
            _idleTime -= Time.deltaTime;
            if (_idleTime > 0f)
                return;

            _idleTime = Random.Range(_minimumIdleTime, _maximumIdleTime);
            _state = RabbitState.Walk;
        }
        
        else if (_state == RabbitState.Walk )
        {
            if (Vector3.Distance(transform.position, _currentWaypoint.position) < 2f)
            {
                _currentWaypoint = GetRandomPoint();
                _state = RabbitState.Idle;
            }

            _agent.SetDestination(_currentWaypoint.position);
        }
    }

    private Transform GetRandomPoint()
    {
        int index = Random.Range(0, _waypoints.Length);
        return _waypoints[index];

        
    }
}

public enum RabbitState
{
    Idle,
    Walk
}
