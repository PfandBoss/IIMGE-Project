using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] items = new GameObject[3];
    public float Radius;
    
    void Awake()
    {
        //Subscribe to player health Spawn armor depending on health --> pity drop
        Player.GetComponent<PlayerStats>().getHealth()
            .Subscribe(i =>
            {
                if (i < 3)
                {
                    SpawnItemsAtRandom(3);
                }
                else if (i == 3)
                {
                    SpawnItemsAtRandom(2);
                }
            })
            .AddTo(this);
    }

    private void SpawnItemsAtRandom(int itemMax)
    {
        Vector3 playerPos = GameObject.Find("FirstPersonPlayer").transform.position;
        
        for (int i = 0; i < 3; i++)
        {
            Vector3 randomPos = Random.insideUnitSphere * Radius;
            randomPos = new Vector3 (playerPos.x + randomPos.x, playerPos.y, playerPos.z + randomPos.z);
            Instantiate(items[Random.Range(0, itemMax)], randomPos, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }
}
