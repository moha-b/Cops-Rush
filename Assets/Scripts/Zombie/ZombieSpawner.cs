using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] List<GameObject> zombieList;
    SpawnPlayer spawnPlayer;
    public bool isZombieAttack;
    // Start is called before the first frame update
    private void Awake()
    {
        spawnPlayer = GameObject.Find("Player Spawner").GetComponent<SpawnPlayer>();
    }
    void Start()
    {
        if (spawnPlayer == null)
        {
            Debug.Log("Spawn Player : " + spawnPlayer);
        }
        Spawn(3);
    }
    public void Spawn(int zombies)
    {
       for (int i = 0; i < zombies; i++)
        {
            Quaternion zombieAngel = Quaternion.Euler(new Vector3(0, 180, 0));
            // Instantiate the player prefab at the specified spawn position
            GameObject zomibeInstance = Instantiate(zombiePrefab, GetZombiePosition(), zombieAngel, transform);
            ZombieController zombieController = zomibeInstance.GetComponent<ZombieController>();
            zombieController.player = spawnPlayer;
            zombieController.spawner = this;
            zombieList.Add(zomibeInstance);
        }
    }
    public Vector3 GetZombiePosition()
    {
        Vector3 position = Random.insideUnitSphere * 0.1f;
        Vector3 newPosition = position + transform.position;
        return newPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isZombieAttack = true;
            spawnPlayer.EnemyDetected(other.gameObject);
            LookAtPlayer(other.gameObject);
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void LookAtPlayer(GameObject target)
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion lookAt = Quaternion.LookRotation(direction);
        lookAt.x = 0;
        lookAt.z = 0;

        transform.rotation = lookAt;
    }
}
