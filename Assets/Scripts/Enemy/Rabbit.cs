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
