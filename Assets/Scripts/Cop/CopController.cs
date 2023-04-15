using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopController : MonoBehaviour
{

    private CopAnimation copAnimation;
    private CopBullets copBullets;

    private void Awake()
    {
        copAnimation = GetComponent<CopAnimation>();
        copBullets = GetComponent<CopBullets>();
    }

    public void StartShooting()
    {
        copBullets.isShootingOn = true;
        StartCoroutine(copBullets.Shooting());
        copAnimation.StartShootingAnim();
    }
    public void StartRunning()
    {
        copBullets.isShootingOn = false;
        copAnimation.StartRunningAnim();
    }
}