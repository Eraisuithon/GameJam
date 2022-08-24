using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource hitSound;
    public AudioSource enemyDieSound;
    public AudioSource jumpSound;
    public AudioSource shotSound;

    public void playHitSound()
    {
        hitSound.Play();
    }

    public void playEnemyDieSound()
    {
        enemyDieSound.Play();
    }

    public void playJumpSound()
    {
        jumpSound.Play();
    }

    public void playShotSound()
    {
        shotSound.Play();
    }
}
