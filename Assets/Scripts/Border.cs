using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private GameObject currentEnemy;
    private Projectile projectileScript;
    Vector3 theBuffer = new Vector3(1, 1, 0);
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Gets the current enemys projectile script which holds spawn location
        currentEnemy = collision.gameObject;
        projectileScript = currentEnemy.GetComponent<Projectile>();
        
        //Gets the spawn pos of the current projectile
        float curX = projectileScript.getSpawnPosX();
        float curY = projectileScript.getSpawnPosY();
        //Checks if the projectile has moved far enough away from the spawnpoint tocollide with something other than the spawn border
        if (collision.gameObject.tag == "Projectile" && curX > (curX + 1.0f) || curY > (curY + 1.0f))
        {
            Destroy(collision.gameObject);
        }
    }
}
