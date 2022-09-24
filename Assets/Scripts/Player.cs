using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float minX, maxX, minY, maxY;
    [SerializeField] int playerHealth = 5;
    [SerializeField] Text textElement;
    [SerializeField] Text gameOverText;
    private Vector2 maxBoundry, minBoundry;
    private Vector2 rawInput;
    private bool canUseSword = true;
    private GameObject theSpawner;
    private HeartSpawner spawnScript;
    private Audio theAudio;
    private GameObject theBoss;
    private HeartBoss bossScript;

    private void Start()
    {
        Camera mainCamera = Camera.main;
        minBoundry = mainCamera.ViewportToWorldPoint(new Vector2(minX, minY));
        maxBoundry = mainCamera.ViewportToWorldPoint(new Vector2(maxX, maxY));
        theSpawner = GameObject.Find("Enemy heart spawner");
        spawnScript = theSpawner.GetComponent<HeartSpawner>();
        theBoss = GameObject.Find("HeartBoss");
        bossScript = theBoss.GetComponent<HeartBoss>();
        theAudio = FindObjectOfType<Audio>();
        theAudio.playBackgroundMusic();
        textElement.text = playerHealth.ToString();
        Time.timeScale = 1;
    }

    void Update()
    {
        Move();
        if (playerHealth <= 0)
        {
            gameOverText.text = "GAME OVER";
            Time.timeScale = 0;
        }
    }

    private void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBoundry.x, maxBoundry.x);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBoundry.y, maxBoundry.y);
        transform.position = newPos;
    }

    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    private void OnLook()
    {
        // Using the new input system to grab current screen pos of mouse
        Vector2 mousePos = Pointer.current.position.ReadValue();
        // Convert the current screen pos to world position
        Vector2 screenPos = new Vector2(mousePos.x, mousePos.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        // Move the player to the current world pos coordinates
        gameObject.transform.position = worldPos;
        
    }

    private void OnFire(InputValue button)
    {
        if (canUseSword)
        {
            Debug.Log("in can use sword");
            Transform swordTransform = this.transform.GetChild(1).transform;
            StartCoroutine(Sword(swordTransform));
        }
        
    }

    private void OnRestart(InputValue button)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnMake(InputValue button)
    {
        bossScript.setTextDelay(0.01f);
        //spawnScript.spawnHeart();
    }

    IEnumerator Sword(Transform theSword)
    {
        theSword.GetComponent<SpriteRenderer>().enabled = true;
        theSword.GetComponent<BoxCollider2D>().enabled = true;
        theAudio.PlaySwordHitClip();
        canUseSword = false;
        yield return new WaitForSeconds(2f);
        theSword.GetComponent<BoxCollider2D>().enabled = false;
        theSword.GetComponent<SpriteRenderer>().enabled = false;
        canUseSword = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Projectile"))
        {
            theAudio.PlayPlayerHitClip();
            playerHealth--;
            textElement.text = playerHealth.ToString();

            
            Debug.Log("hit by projectile");
        }
        else
        {

        }

        if (GameObject.FindGameObjectWithTag("EnemyHeart"))
        {
            //do nothing
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Projectile"))
        {
            Debug.Log("hit by projectile");
        }
    }*/
}
