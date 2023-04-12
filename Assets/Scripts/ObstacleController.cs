using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    SpawnPlayer SpawnPlayer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer = GameObject.FindGameObjectWithTag("PlayerSpawner").GetComponent<SpawnPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SpawnPlayer.KillCop(other.gameObject);
        }
    }
}
