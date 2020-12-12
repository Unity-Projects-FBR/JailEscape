using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform ShootingPosition;
    public Bullet BulletPrefab;
    public GameObject ArmSolver;
    public float TimeBtwShoots = 0.2f;

    protected float TimeFromLastShoot = 0f;

    protected void Shoot()
    {
        Instantiate(BulletPrefab, ShootingPosition.position, transform.rotation);
    }
}
