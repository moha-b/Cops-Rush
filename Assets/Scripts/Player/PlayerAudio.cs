using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gateClip, congratesClip, failClip, shootClip;

    public void PlayCongratesSound()
    {
        PlayAudio(congratesClip);
        StopBackgroundMusic();
    }

    public void PlayFailSound()
    {
        PlayAudio(failClip);
        StopBackgroundMusic();
    }

    public void PlayGateSound()
    {
        PlayAudio(gateClip);
    }

    public void PlayShootingSound()
    {
        PlayAudio(shootClip);
    }

    public void PlayAudio(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip, 0.5f);
        }
    }
    private void StopBackgroundMusic()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
    }
}
