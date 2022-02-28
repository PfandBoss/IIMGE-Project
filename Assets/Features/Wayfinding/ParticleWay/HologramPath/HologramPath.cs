using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class HologramPath : MonoBehaviour
{
    [Header("Agents Configuration")]
    [SerializeField] private Transform player;
    [SerializeField] public Transform target;
    
    [SerializeField] private ParticleSystem _trail;

    private NavMeshPath _currentPath;
    private NavMeshAgent _navAgent;

    private int _trailIterator = 0;
    
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceFromPlayer = 1f;
    [SerializeField] private float maxDistanceFromPlayer = 8f;
    [SerializeField] private float distanceFromGround = 0.3f;

    // Start is called before the first frame update
    private void Start()
    {
        _currentPath = new NavMeshPath();
        _trail = Instantiate(_trail);
        _trail.transform.position = player.position;
    }

    // Update is called once per frame
    private void Update()
    {
        NavMeshHit targetNavMeshPos;
        bool p1Valid = NavMesh.SamplePosition(target.position, out targetNavMeshPos, 5.0f, NavMesh.AllAreas);

        NavMeshHit playerNavMeshPos;
        bool p2Valid = NavMesh.SamplePosition(player.position, out playerNavMeshPos, 5.0f, NavMesh.AllAreas);

        if (p1Valid && p2Valid)
            if (NavMesh.CalculatePath(playerNavMeshPos.position, targetNavMeshPos.position, NavMesh.AllAreas, _currentPath))
                for (int i = 0; i < _currentPath.corners.Length - 1; i++)
                    Debug.DrawLine(_currentPath.corners[i], _currentPath.corners[i + 1], Color.red);
        
        MoveAlongPath();
    }

    private void MoveAlongPath()
    {
        distanceFromPlayer += moveSpeed * Time.deltaTime;
        if (distanceFromPlayer > maxDistanceFromPlayer)
        {
            distanceFromPlayer = 0;
            _trail.Stop();
            _trail.transform.position = player.position;
            _trail.Play();
        }


        int i = 0;
        Vector3 from = _currentPath.corners[i];
        Vector3 to = _currentPath.corners[i + 1];

        float distance = 0;


        while (distance + Vector3.Distance(from, to) < distanceFromPlayer && i + 1 < _currentPath.corners.Length)
        {
            distance += Vector3.Distance(from, to);

            from = _currentPath.corners[i];
            to = _currentPath.corners[i + 1];
            
            i++;
        }

        _trail.transform.position = from + (to - from).normalized * (distanceFromPlayer - distance) + Vector3.up * distanceFromGround;
    }

    public void SetActive(bool active_p)
    {
        this.SetActive(active_p);
    }
}