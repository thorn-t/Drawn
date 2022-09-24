using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemyHeartPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnHeart()
    {
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyHeartPrefab, spawnPoints[randSpawnPoint].position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spawnHeart();
    }
}
