using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyAI : MonoBehaviour
{
    public Transform[] waypoints;
    private int _currentWaypointIndex;

    private const float SightRange = 15;
    private const float AttackRange = 4;
    private bool isAttacking;

    //NavMesh Stuff
    public GameObject player;
    private PlayerStats _playerStats;
    private UnityEngine.AI.NavMeshAgent _agent;


    private void Start()
    {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _playerStats = player.GetComponent<PlayerStats>();
        _playerStats.ApplyDamage(1);
    }

    private void Update()
    {
        if (isAttacking) return;
        var distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= SightRange)
        {
            if (distanceToPlayer <= AttackRange)
            {
                StopAllCoroutines();
                StartCoroutine(Attack());
            }
            else
            {
                RunAtPlayer();
            }
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        var wp = waypoints[_currentWaypointIndex];
        if (Vector3.Distance(transform.position, wp.position) < 1f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            var position = wp.position;
            _agent.destination = position;
            transform.LookAt(position);
        }
        
    }

    private void RunAtPlayer()
    {
        var position = player.transform.position;
        _agent.destination = position;
        transform.LookAt(position);
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        _agent.isStopped = true;
        yield return new WaitForSeconds(2);
        if (Vector3.Distance(transform.position, player.transform.position) <= AttackRange)
        {
            _playerStats.ApplyDamage(1);
        }
        isAttacking = false;
        _agent.isStopped = false;
    }
}