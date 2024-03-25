using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public Move player;
    public float viewAngle;
    private float _time = 1f;
    private bool RoarEnabled = true;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private Vector3 LastPosition;

    public float damage = 10f;

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
        if (player.GetComponent<KillsCount>().Win)
        {
            Destroy(gameObject);
        }
        if (player.GetComponent<PlayerHealth>().IsDead)
        {
            transform.localEulerAngles = player.GetComponent<PlayerHealth>().EnemyRotation;
            transform.position = player.GetComponent<PlayerHealth>().EnemyPosition;
            if (gameObject != player.GetComponent<PlayerHealth>().enemy)
            {
                Destroy(gameObject);
            }
        }
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
    public void AddKill()
    {
        player.GetComponent<KillsCount>().kills++;
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
    void FaceTarget()
    {
        var turnTowardNavSteeringTarget = _navMeshAgent.steeringTarget;
        Vector3 direction = (turnTowardNavSteeringTarget - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            //_navMeshAgent.preventRotation = true;
            //FaceTarget();
            //transform.LookAt(player.transform.position);
            _navMeshAgent.destination = player.transform.position;
            
            if (_navMeshAgent.remainingDistance <= 10f && RoarEnabled)
            {
                GetComponent<Animator>().SetTrigger("Roar");
                RoarEnabled = false;
            }
            
        }
        else
        {
            RoarEnabled = true;
            _navMeshAgent.destination = LastPosition;
        }
    }

    public void ChangeExperienceBar()
    {
        player.GetComponent<PlayerProgress>().AddExperience(66.7f);
    }
}
