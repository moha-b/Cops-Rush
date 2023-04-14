using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopAnimation : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
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
