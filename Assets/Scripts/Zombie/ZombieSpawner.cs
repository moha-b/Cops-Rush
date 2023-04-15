using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] List<GameObject> zombieList;
    [SerializeField] int enemysNumber = 5;
    PlayerController playerController;
    EnemySpawnerController controller;
    public bool isZombieAttack;

    private void Awake()
    {
        playerController = GameObject.Find("Player Spawner").GetComponent<PlayerController>();
        controller = GetComponent<EnemySpawnerController>();
    }
    void Start()
    {
        Spawn(enemysNumber);
    }
    public void Spawn(int zombies)
    {
       for (int i = 0; i < zombies; i++)
        {
            Quaternion zombieAngel = Quaternion.Euler(new Vector3(0, 180, 0));
            // Instantiate the player prefab at the specified spawn position
            GameObject zomibeInstance = Instantiate(zombiePrefab, GetZombiePosition(), zombieAngel, transform);
            ZombieMovement zombieMovement = zomibeInstance.GetComponent<ZombieMovement>();
            ZombieController zombieController  = zomibeInstance.GetComponent<ZombieController>();
            zombieController.controller = controller;
            zombieMovement.player = playerController;
            zombieMovement.spawner = this;
            zombieList.Add(zomibeInstance);
        }
    }
    public Vector3 GetZombiePosition()
    {
        Vector3 position = Random.insideUnitSphere * 0.1f;
        Vector3 newPosition = position + transform.position;
        return newPosition;
    }

    public void RemoveFromList(GameObject zombie)
    {
        zombieList.Remove(zombie);
        Destroy(zombie);
    }

    public int ZombieNumber()
    {
        return zombieList.Count;
    }


}
 