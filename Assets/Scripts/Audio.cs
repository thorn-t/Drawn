using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("backgroundMusic")]
    [SerializeField] AudioClip backgroundMusic;
    [SerializeField] float backgroundMusicVolume = 1f;
    [Header("enemyHit")]
    [SerializeField] AudioClip enemyHitClip;
    [SerializeField] float enemyHitVolume = 1f;
    [Header("playerHit")]
    [SerializeField] AudioClip playerHitClip;
    [SerializeField] float playerHitVolume = 1f;
    [Header("swordHit")]
    [SerializeField] AudioClip swordHitClip;
    [SerializeField] float swordHitVolume = 1f;
    [Header("phaseTwoBGM")]
    [SerializeField] AudioClip phaseTwoBGM;
    [SerializeField] float phaseTwoBGMVolume = 1f;

    public void playBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            AudioSource.PlayClipAtPoint(backgroundMusic, Camera.main.transform.position, backgroundMusicVolume);
            
        }
    }


    public void PlaySwordHitClip()
    {
        if (swordHitClip != null)
        {
            AudioSource.PlayClipAtPoint(swordHitClip, Camera.main.transform.position, swordHitVolume);
        }
    }


    public void PlayEnemyHitClip()
    {
        if (enemyHitClip != null)
        {
            AudioSource.PlayClipAtPoint(enemyHitClip, Camera.main.transform.position, enemyHitVolume);
        }
    }

    public void PlayPlayerHitClip()
    {
        if (playerHitClip != null)
        {
            AudioSource.PlayClipAtPoint(playerHitClip, Camera.main.transform.position, playerHitVolume);
        }
    }

    public void PlayPhaseTwoBGM()
    {
        if (phaseTwoBGM != null)
        {
            AudioSource.PlayClipAtPoint(phaseTwoBGM, Camera.main.transform.position, phaseTwoBGMVolume);
        }
    }
}
