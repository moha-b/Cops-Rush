using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    public List<GameObject> playerList;

    // Scripts
    PlayerMovement playerMovement;
    PlayerRotation playerRotation;
    PlayerAudio playerAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerRotation = GetComponent<PlayerRotation>();
        playerAudio = GetComponent<PlayerAudio>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            playerMovement.StopPlayer();
            GameManager.Instance.ShowWinPanel();
            playerAudio.PlayCongratesSound();
        }
    }

    public void EnemyDetected(GameObject enemy)
    {
        playerMovement.StopPlayer();
        playerRotation.LookAtEnemy(enemy);
        StartShooting();
    }


    public void Spawn(int gateValue,GateType gateType)
    {
        playerAudio.PlayGateSound();
        if (gateType == GateType.ADDITION)
        {
            for (int i = 0; i < gateValue; i++)
            {
                // Instantiate the player prefab at the specified spawn position
                GameObject playerInstance = Instantiate(playerPrefab, GetPlayerPosition(), Quaternion.identity, transform);
                playerList.Add(playerInstance);
            }
        }
        else if(gateType == GateType.MULTIPLY)
        {
            int playerCount = (playerList.Count * gateValue) - playerList.Count;
            for (int i = 0; i < playerCount; i++)
            {
                // Instantiate the player prefab at the specified spawn position
                GameObject playerInstance = Instantiate(playerPrefab, GetPlayerPosition(), Quaternion.identity, transform);
                playerList.Add(playerInstance);
            }
        }
        
    }

    public void KillCop(GameObject cop)
    {
        playerList.Remove(cop);
        Destroy(cop);
        DetectCopCount();
    }

    public void AllZomibesKilled()
    {
        playerRotation.LookForward();
        playerMovement.MovePlayer();
    }

    private void DetectCopCount()
    {
        if (playerList.Count <= 0)
        {
            playerMovement.StopPlayer();
            GameManager.Instance.ShowFailPanel();
            playerAudio.PlayFailSound();
            
        }
    }

    private void StartShooting()
    {
        for(int i = 0;i < playerList.Count;i++)
        {
            PlayerController cop = playerList[i].GetComponent<PlayerController>();
            cop.StartShooting();
            playerAudio.PlayShootingSound();
        }
    }
    private void StartRunning()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            PlayerController cop = playerList[i].GetComponent<PlayerController>();
            cop.StartRunning();
        }
    }

    public Vector3 GetPlayerPosition()
    {
        Vector3 position = Random.insideUnitSphere * 0.1f;
        Vector3 newPosition = position + transform.position;
        return newPosition;
    }
}
