using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeart : MonoBehaviour
{
    private GameObject currentEnemy;
    private EnemyHealth healthScript;
    private Audio theAudio;


    // Start is called before the first frame update
    void Start()
    {
        currentEnemy = GameObject.Find("HeartBoss");
        healthScript = currentEnemy.GetComponent<EnemyHealth>();
        theAudio = FindObjectOfType<Audio>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!GameObject.FindGameObjectWithTag("PlayerSword").GetComponent<BoxCollider2D>().enabled == false){
            if (GameObject.FindGameObjectWithTag("PlayerSword"))
            {
                StartCoroutine(damageHeart());
                Debug.Log("SwordHit");
            }
            
        }
    }

    IEnumerator damageHeart()
    {
        bool takingDamage = true;
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        Destroy(gameObject);
        if (takingDamage == true)
        {
            theAudio.PlayEnemyHitClip();
            takingDamage = false;
            healthScript.takeDamage();
        }
        else
        {
            Debug.Log("shouldnt do dmg");
        }
        
    }
}
