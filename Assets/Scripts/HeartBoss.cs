using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBoss : MonoBehaviour
{
    [SerializeField] GameObject topLeftToRightSpawner, bottomLeftToRightSpawner;
    [SerializeField] string textValue;
    [SerializeField] Text textElement;

    private float textDelay = 0.1f;
    [SerializeField] string fullText;
    [SerializeField] string currentText = "";

    private GameObject currentEnemy;
    private EnemyHealth healthScript;
    private GameObject theSpawner;
    private HeartSpawner spawnScript;


    private string message0 = "Hello friend.";
    private string message1 = "To draw your sword press the spacebar.";
    private string message2 = "It is dangerous to keep it out so you have to redraw it every time.";
    private string message3 = "I have something else for you.";
    private string message4 = "THATS NOT IT! WHATEVER YOU DO KEEP YOUR SWORD AWAY FROM IT!";
    private string message5 = "WHY DO THEY NEVER LISTEN!";

    private bool talking = false;
    private bool topSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        currentEnemy = GameObject.Find("HeartBoss");
        healthScript = currentEnemy.GetComponent<EnemyHealth>();
        StartCoroutine(ShowText(message0, message1, message2, message3, message4));
        theSpawner = GameObject.Find("Enemy heart spawner");
        spawnScript = theSpawner.GetComponent<HeartSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.getEnemyHealth() == 4 && talking == false)
        {
            StartCoroutine(StartBattle(message5));
            talking = true;
            Instantiate(bottomLeftToRightSpawner);
        }

        if (healthScript.getEnemyHealth() == 3 && topSpawned == false)
        {
            topSpawned = true;
            Instantiate(topLeftToRightSpawner);
        }

    }

    public void setTextDelay(float delay)
    {
        textDelay = delay;
    }
    

    IEnumerator StartBattle(string message5)
    {
        for (int i = 0; i < message5.Length + 1; i++)
        {
            currentText = message5.Substring(0, i);
            textElement.text = currentText;
            yield return new WaitForSeconds(textDelay);
        }
    }

    IEnumerator ShowText(string message, string message1, string message2, string message3, string message4)
    {
        for (int i = 0; i < message.Length + 1; i++)
        {
            currentText = message.Substring(0, i);
            textElement.text = currentText;
            yield return new WaitForSeconds(textDelay);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < message1.Length + 1; i++)
        {
            currentText = message1.Substring(0, i);
            textElement.text = currentText;
            yield return new WaitForSeconds(textDelay);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < message2.Length + 1; i++)
        {
            currentText = message2.Substring(0, i);
            textElement.text = currentText;
            yield return new WaitForSeconds(textDelay);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < message3.Length + 1; i++)
        {
            currentText = message3.Substring(0, i);
            textElement.text = currentText;
            yield return new WaitForSeconds(textDelay);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < message4.Length + 1; i++)
        {
            currentText = message4.Substring(0, i);
            textElement.text = currentText;
            yield return new WaitForSeconds(textDelay);
            
        }
        spawnScript.spawnHeart();
    }

}
