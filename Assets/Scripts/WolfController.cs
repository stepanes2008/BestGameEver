using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfController : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public Move player;
    public float viewAngle;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private Vector3 LastPosition;

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
    }

    private void NoticePlayerUpdate()
    {
        // !стандартная конструкция для Raycast!
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
        // !стандартная конструкция для Raycast!
    }
    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0 && _isPlayerNoticed == false)
        {
            PickNewPatrolPoint();
        }
    }
    private void PickNewPatrolPoint()
    {
        LastPosition = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
        else
        {
            _navMeshAgent.destination = LastPosition;
        }
    }
}

