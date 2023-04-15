using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource,backgroundAudio;
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
        backgroundAudio.Stop();
    }
}
