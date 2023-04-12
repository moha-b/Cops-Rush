using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
