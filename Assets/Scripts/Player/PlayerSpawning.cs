using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawning : MonoBehaviour
{
    private static PlayerSpawning _instance; // private static instance field
    public static PlayerSpawning Instance { get { return _instance; } } // public static instance property

    [SerializeField] GameObject copPrefab;
    public List<GameObject> copList;

    private void Awake()
    {
        // Ensure only one instance of the class is created
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }

    public void Spawn(int gateValue, GateType gateType)
    {
        //audioController.PlayGateSound();
        if (gateType == GateType.ADDITION)
        {
            for (int i = 0; i < gateValue; i++)
            {
                // Instantiate the player prefab at the specified spawn position
                GameObject playerInstance = Instantiate(copPrefab, GetPlayerPosition(), Quaternion.identity, transform);
                copList.Add(playerInstance);
            }
        }
        else if (gateType == GateType.MULTIPLY)
        {
            int playerCount = (copList.Count * gateValue) - copList.Count;
            for (int i = 0; i < playerCount; i++)
            {
                // Instantiate the player prefab at the specified spawn position
                GameObject playerInstance = Instantiate(copPrefab, GetPlayerPosition(), Quaternion.identity, transform);
                copList.Add(playerInstance);
            }
        }

    }
    private Vector3 GetPlayerPosition()
    {
        Vector3 position = Random.insideUnitSphere * 0.1f;
        Vector3 newPosition = position + transform.position;
        return newPosition;
    }
}