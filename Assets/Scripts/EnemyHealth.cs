using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int currentHealth;
    [SerializeField] Sprite secondPhase;
    [SerializeField] Text textElement;
    private Audio theAudio;
    private GameObject theSpawner;
    private HeartSpawner spawnScript;
    private float delay;
    // Start is called before the first frame update
    void Start()
    {
        theAudio = FindObjectOfType<Audio>();
        theSpawner = GameObject.Find("Enemy heart spawner");
        spawnScript = theSpawner.GetComponent<HeartSpawner>();
        delay = Random.Range(4, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage()
    {
        currentHealth -= 1;
        if (currentHealth == 4)
        {
            StartCoroutine(spawnNewHeart());
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = secondPhase;
        }

        if (currentHealth == 3)
        {
            StartCoroutine(spawnNewHeart());
        }

        if (currentHealth == 2)
        {
            StartCoroutine(spawnNewHeart());
        }

        if(currentHealth == 1)
        {
            StartCoroutine(spawnNewHeart());
        }

        if(currentHealth <= 0)
        {
            textElement.text = "YOU WIN";
            Time.timeScale = 0;
        }
        
    }

    IEnumerator spawnNewHeart()
    {
        yield return new WaitForSeconds(delay);
        spawnScript.spawnHeart();
    }


    public int getEnemyHealth()
    {
        return currentHealth;
    }
}
