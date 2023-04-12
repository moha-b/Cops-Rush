using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public SpawnPlayer player;
    public ZombieSpawner spawner;
    bool isZombieAlive;
    // Start is called before the first frame update
    void Start()
    {
        isZombieAlive = true;
    }
    private void FixedUpdate()
    {
        if (spawner.isZombieAttack)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.fixedDeltaTime * 1.5f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && isZombieAlive == true)
        {
            isZombieAlive = false;
            spawner.ZombieAttackTheCops(cop: collision.gameObject, zombie: gameObject);
        }
    }
}
