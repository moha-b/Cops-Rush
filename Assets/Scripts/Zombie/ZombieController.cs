using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public SpawnPlayer player;
    public ZombieSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (spawner.isZombieAttack)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.fixedDeltaTime * 1.5f);
        }
    }
}
