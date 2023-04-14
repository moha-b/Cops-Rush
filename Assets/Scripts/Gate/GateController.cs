using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GateType { MULTIPLY, ADDITION };
public class GateController : MonoBehaviour
{
    bool isPlayerTouchGate = true;
    SpawnPlayer spawnPlayer;
    PlayerSpawning playerSpawning;
    GateHolderController gateController;
    int gateValue;
    public GateType gateType;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        gateValue = 5;
        spawnPlayer = GameObject.FindGameObjectWithTag("PlayerSpawner").GetComponent<SpawnPlayer>();
        playerSpawning = GameObject.FindGameObjectWithTag("PlayerSpawner").GetComponent<PlayerSpawning>();
        gateController = transform.parent.gameObject.GetComponent<GateHolderController>();
        UpdateText();
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Player" && isPlayerTouchGate)
        {
            isPlayerTouchGate = false;
            gateController.CloseGate();
            playerSpawning.Spawn(gateValue, gateType);
            Destroy(this.gameObject);
        }
    }

    private void UpdateText()
    {
        switch(gateType)
        {
            case GateType.MULTIPLY:
                text.text = "X"+gateValue.ToString();
                break; 
            case GateType.ADDITION:
                text.text = "+" + gateValue.ToString();
                break;
            default: 
                break;
        }
    }
}
