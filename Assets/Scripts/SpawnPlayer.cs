using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Spawn(int playerCount)
    {
        for (int i = 0; i < playerCount; i++)
        {
            // Instantiate the player prefab at the specified spawn position
            GameObject playerInstance = Instantiate(playerPrefab, GetPlayerPosition(), Quaternion.identity, transform);
        }
    }

    public Vector3 GetPlayerPosition()
    {
        Vector3 position = Random.insideUnitSphere * 0.1f;
        Vector3 newPosition = position + transform.position;
        return newPosition;
    }
}
