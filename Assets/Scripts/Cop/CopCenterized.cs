using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopCenterized : MonoBehaviour
{
    private Transform playerSpawnerCenter;
    private float goToCenter = 5f;
    // Start is called before the first frame update
    void Start()
    {
        playerSpawnerCenter = transform.parent.gameObject.transform;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerSpawnerCenter.position, Time.fixedDeltaTime * goToCenter);
    }
}
