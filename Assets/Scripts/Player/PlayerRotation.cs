using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public void LookAtEnemy(GameObject enemy)
    {
        Vector3 direction = enemy.transform.position - transform.position;
        Quaternion lookAt = Quaternion.LookRotation(direction);
        lookAt.x = 0;
        lookAt.z = 0;

        transform.rotation = lookAt;
    }
    public void LookForward()
    {
        transform.rotation = Quaternion.identity;
    }
}
