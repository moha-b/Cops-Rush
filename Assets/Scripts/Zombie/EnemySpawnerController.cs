using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    ZombieSpawner zombieSpawner;
    PlayerController playerController;

    private void Start()
    {
        zombieSpawner = GetComponent<ZombieSpawner>();
        playerController = GameObject.Find("Player Spawner").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            zombieSpawner.isZombieAttack = true;
            playerController.EnemyDetected(gameObject);
            LookAtPlayer(other.gameObject);
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void LookAtPlayer(GameObject target)
    {
        // Calculate direction from this object's position to the player's position
        Vector3 direction = target.transform.position - transform.position;

        // Calculate rotation to look at the direction
        Quaternion lookAtRotation = Quaternion.LookRotation(direction);

        // Set rotation for this object
        transform.rotation = lookAtRotation;
    }

    public void ZombieAttackTheCops(GameObject cop, GameObject zombie)
    {
        zombieSpawner.RemoveFromList(zombie);
        CheckZombieCount();
        playerController.KillCop(cop);
    }

    public void ZombieGotShoot(GameObject zombie)
    {
        zombieSpawner.RemoveFromList(zombie);
        CheckZombieCount();
    }

    private void CheckZombieCount()
    {
        if (zombieSpawner.ZombieNumber() <= 0)
        {
            playerController.AllZomibesKilled();
        }
    }
}
