using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Scripts
    PlayerMovement playerMovement;
    PlayerRotation playerRotation;
    PlayerSpawning playerSpawning;
    AudioController audioController;
    
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerRotation = GetComponent<PlayerRotation>();
        playerSpawning = GetComponent<PlayerSpawning>();
        audioController = GameObject.Find("AudioSource").GetComponent<AudioController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            playerMovement.StopPlayer();
            GameManager.Instance.ShowWinPanel();
            audioController.PlayCongratesSound();
        }
    }

    public void KillCop(GameObject cop)
    {
        playerSpawning.RemoveFromList(cop);
        DetectCopCount();
    }

    private void DetectCopCount()
    {
        if (playerSpawning.CopsNumber() <= 0)
        {
            playerMovement.StopPlayer();
            GameManager.Instance.ShowFailPanel();
            audioController.PlayFailSound();
        }
    }

    public void EnemyDetected(GameObject enemy)
    {
        playerMovement.StopPlayer();
        playerRotation.LookAtEnemy(enemy);
        StartShooting();
    }

    public void AllZomibesKilled()
    {
        playerRotation.LookForward();
        playerMovement.MovePlayer();
        StartRunning();
    }

    private void StartShooting()
    {
        for(int i = 0;i < playerSpawning.CopsNumber();i++)
        {
            CopController cop = playerSpawning.getCop(i).GetComponent<CopController>();
            cop.StartShooting();
            audioController.PlayShootingSound();
        }
    }

    private void StartRunning()
    {
        for (int i = 0; i < playerSpawning.CopsNumber(); i++)
        {
            CopController cop = playerSpawning.getCop(i).GetComponent<CopController>();
            cop.StartRunning();
        }
    }
}