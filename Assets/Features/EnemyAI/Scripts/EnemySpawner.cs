using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    private GameObject bossObject;
    [SerializeField]
    private Transform bossSpawnPoint;
    [SerializeField]
    private CompassBarElement compassBar;
    [SerializeField]
    private HologramPath hologramPath;

    private GameObject currentEnemy;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNextEnemy();
    }

    public void SpawnNextEnemy()
    {
        if(enemies.Count > 0)
        {
            var pos = EnemyAI.RandomNavSphere(transform.position, 100, -1);
            currentEnemy = Instantiate(enemies[0],pos,new Quaternion());
            compassBar.target = currentEnemy.transform;
            hologramPath.target = currentEnemy.transform;
            enemies.RemoveAt(0);
            return;
        }
        else if (bossObject != null)
        {
            currentEnemy = Instantiate(bossObject, bossSpawnPoint.position, new Quaternion());
            compassBar.target = currentEnemy.transform;
            hologramPath.target = currentEnemy.transform;
            bossObject = null;
            return;
        }
        
        //Win Screen here
    }
    
}
