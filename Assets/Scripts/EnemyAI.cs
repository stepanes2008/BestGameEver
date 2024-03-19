using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public Move player;
    public float viewAngle;
    private float _time = 1f;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private Vector3 LastPosition;

    public float damage = 33.4f;

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
        if (GetComponent<EnemyHealth>()._time == 0f)
        {
            if (player.GetComponent<PlayerHealth>().IsDead == false)
            {
                NoticePlayerUpdate();
                ChaseUpdate();
                AttackUpdate();
            }
            PatrolUpdate();
            _time += Time.deltaTime;
        }
    }
    private void AttackUpdate()
    {
        if (_isPlayerNoticed && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            player.GetComponent<PlayerHealth>().DealDamage(damage * Time.deltaTime, gameObject);
            GetComponent<Animator>().SetTrigger("Attack");
        }
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
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _isPlayerNoticed == false)
        {
            PickNewPatrolPoint();
        }
    }
    public void PickNewPatrolPoint()
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
