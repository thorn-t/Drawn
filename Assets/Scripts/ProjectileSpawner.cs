using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    private bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(spawnProjectiles());
        }
    }


    IEnumerator spawnProjectiles()
    {
        
        Instantiate(projectile, transform.position, Quaternion.identity);
        canSpawn = false;
        yield return new WaitForSeconds(0.3f);
        canSpawn = true;
    }
}
