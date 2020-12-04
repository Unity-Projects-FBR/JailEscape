using System;
using UnityEngine;

public class PlayerWeaponController : WeaponController
{
    private Vector2 MousePos;

    public void Update()
    {
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void FixedUpdate()
    {
        ArmSolver.transform.position = MousePos;
        TimeFromLastShoot += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && TimeFromLastShoot > TimeBtwShoots)
        {
            TimeFromLastShoot = 0;
            Shoot();
        }
    }
}
