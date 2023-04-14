using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public EnemySpawnerController controller;
    bool isZombieAlive;
    // Start is called before the first frame update
    void Start()
    {
        isZombieAlive = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && isZombieAlive == true)
        {
            isZombieAlive = false;
            controller.ZombieAttackTheCops(cop: collision.gameObject, zombie: gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            controller.ZombieGotShoot(gameObject);
            Destroy(other.gameObject);
        }
    }
}
