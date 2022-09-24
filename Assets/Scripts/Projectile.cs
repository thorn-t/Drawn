using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float moveSpeed = 3f;
    private bool directionDown = false;
    private bool directionUp = false;
    Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;

        if (spawnPos.y > 0f)
        {
            directionDown = true;
            directionUp = false;
        }
        else if (spawnPos.y < -4f)
        {
            directionUp = true;
            directionDown = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (directionDown)
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
        else if (directionUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    public float getSpawnPosY()
    {
        return spawnPos.y;
    }

    public float getSpawnPosX()
    {
        return spawnPos.x;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TopBorder" && directionUp)
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "BottomBorder" && directionDown)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TopBorder" && directionUp)
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "BottomBorder" && directionDown)
        {
            Destroy(gameObject);
        }
    }
}
