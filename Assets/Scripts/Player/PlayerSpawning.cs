using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawning : MonoBehaviour
{
    [SerializeField] GameObject copPrefab;
    public List<GameObject> copList;
    AudioController audioController;

    private void Start()
    {
        audioController = GameObject.Find("AudioSource").GetComponent<AudioController>();
    }

    public void Spawn(int gateValue, GateType gateType)
    {
        audioController.PlayGateSound();
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

    public void RemoveFromList(GameObject cop)
    {
        copList.Remove(cop);
        Destroy(cop);
    }

    public int CopsNumber()
    {
        return copList.Count;
    }

    public GameObject getCop(int i)
    {
        return copList[i];
    }
}