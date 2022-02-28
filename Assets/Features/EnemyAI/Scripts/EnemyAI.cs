using System.Collections;
using UnityEngine;
using UniRx;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform[] waypoints;
    private int _currentWaypointIndex;
    public HealthBar HealthBar;
    public HologramPath holo;

    [SerializeField]private  float SightRange ;
    [SerializeField]private  float AttackRange;
    private bool isAttacking;
    [SerializeField]
    private ReactiveProperty<int> health;
    
   

    //NavMesh Stuff
    public GameObject player;
    private PlayerStats _playerStats;
    private UnityEngine.AI.NavMeshAgent _agent;
    [SerializeField] private FighterController _fighterController;


    private void Start()
    {
        player = GameObject.Find("FirstPersonPlayer");
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _playerStats = player.GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (isAttacking)
        {
            //transform.LookAt(player.transform.position);
            return;
        }
        var distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= SightRange)
        {
            if (gameObject.tag == "Boss")
                player.SendMessage("DisableHolo", SendMessageOptions.DontRequireReceiver);
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
        /*
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
        */

        if (Vector3.Distance(transform.position, _agent.destination) > 1f)
            return;

        var pos = RandomNavSphere(transform.position, 20f, -1);
        _agent.destination = pos;
        transform.LookAt(pos);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
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
        if (gameObject.tag == "Boss")
            yield return new WaitForSeconds(1.5f);
        else
            yield return new WaitForSeconds(0.25f);
        if (Vector3.Distance(transform.position, player.transform.position) <= AttackRange)
        {
            if(gameObject.tag != "Boss")
                _fighterController.AIPunch();
            else
                _fighterController.AICombo();
        }
        isAttacking = false;
        _agent.isStopped = false;
    }

    public void ApplyDamage(int dmg)
    {
        health.Value -= dmg;
        if (health.Value <= 0)
        {
            player.SendMessage("SpawnNextEnemy", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
            Destroy(HealthBar.gameObject);
        }
    }

    public ReactiveProperty<int> getHealth()
    {
        return health;
    }
}