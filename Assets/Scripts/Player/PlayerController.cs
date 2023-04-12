using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public GameObject bullet;
    public Transform bulletTransform;
    private Transform playerSpawnerCenter;
    int bulletSpeed = 10;
    float goToCenter = 5f;
    bool isShootingOn = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerSpawnerCenter = transform.parent.gameObject.transform;
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerSpawnerCenter.position, Time.fixedDeltaTime * goToCenter) ;
    }

    public void StartShooting()
    {
        isShootingOn = true;
        StartCoroutine(Shooting());
        StartShootingAnim();
    }
    public void StartRunning()
    {
        isShootingOn = false;
        StartRunningAnim();
    }
    IEnumerator Shooting()
    {
        while (isShootingOn)
        {
            Shoot();
            yield return new WaitForSeconds(1f);
        }
    }
    private void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet,bulletTransform.position,Quaternion.identity);
        Rigidbody rigidbody = bulletInstance.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * bulletSpeed;
    }
    
    public void StartRunningAnim()
    {
        animator.SetBool("isShooting", false);
        animator.SetBool("isRunning", true);
    }

    public void StartShootingAnim()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isShooting", true);
    }
}
