using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GateType { MULTIPLY, ADDITION };
public class GateController : MonoBehaviour
{
    bool isPlayerTouchGate = true;
    SpawnPlayer spawnPlayer;
    GateHolderController gateController;
    int gateValue;
    GateType gateType;
    public TMPro.TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        gateValue = 2;
        spawnPlayer = GameObject.Find("Player Spawner").GetComponent<SpawnPlayer>();
        gateController = transform.parent.gameObject.GetComponent<GateHolderController>();
        UpdateText();
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Player" && isPlayerTouchGate)
        {
            isPlayerTouchGate = false;
            gateController.CloseGate();
            Destroy(gameObject);
            spawnPlayer.Spawn(2,gateType);
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
