using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHolderController : MonoBehaviour
{
   public void CloseGate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(0) != null)
            {
                transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
