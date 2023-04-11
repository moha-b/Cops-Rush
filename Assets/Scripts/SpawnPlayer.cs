using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] List<GameObject> playerList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Spawn(int gateValue,GateType gateType)
    {
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
            Debug.Log("Inside");
            int playerCount = (playerList.Count * gateValue) - playerList.Count;
            for (int i = 0; i < playerCount; i++)
            {
                // Instantiate the player prefab at the specified spawn position
                Debug.Log("Instantiate");
                GameObject playerInstance = Instantiate(playerPrefab, GetPlayerPosition(), Quaternion.identity, transform);
                Debug.Log("Expand The List");
                playerList.Add(playerInstance);
            }
        }
        
    }

    public void DestroyCop(GameObject cop)
    {
        playerList.Remove(cop);
        Destroy(cop);
    }

    public Vector3 GetPlayerPosition()
    {
        Vector3 position = Random.insideUnitSphere * 0.1f;
        Vector3 newPosition = position + transform.position;
        return newPosition;
    }
}
