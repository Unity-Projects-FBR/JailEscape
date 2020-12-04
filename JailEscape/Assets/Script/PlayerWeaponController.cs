using System;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public Camera cam;
    public GameObject Solver;
    public float TimeBtwShoots = 0.2f;
    public Bullet BulletPrefab;
    public Transform ShootingPosition;

    private Vector2 MousePos;
    private float TimeFromLastShoot = 0f;

    public void Update()
    {
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void FixedUpdate()
    {
        Solver.transform.position = MousePos;

        TimeFromLastShoot += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && TimeFromLastShoot > TimeBtwShoots)
        {
            TimeFromLastShoot = 0;
            Shoot();
        }

    }

    private void Shoot()
    {
        Instantiate(BulletPrefab, ShootingPosition.position, transform.rotation);
    }
}
