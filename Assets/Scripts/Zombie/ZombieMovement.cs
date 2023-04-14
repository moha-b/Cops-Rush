using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public PlayerController player;
    public ZombieSpawner spawner;

    private void FixedUpdate()
    {
        if (spawner.isZombieAttack)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.fixedDeltaTime * 1.5f);
        }
    }
}
