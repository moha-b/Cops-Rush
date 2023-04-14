using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopBullets : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public int bulletSpeed = 10;
    public bool isShootingOn = false;

    public IEnumerator Shooting()
    {
        while (isShootingOn)
        {
            Shoot();
            yield return new WaitForSeconds(1f);
        }
    }
    private void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        Rigidbody rigidbody = bulletInstance.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * bulletSpeed;
    }
}