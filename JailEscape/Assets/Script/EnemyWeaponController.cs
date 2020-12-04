using UnityEngine;

public class EnemyWeaponController : WeaponController
{
    public Transform Target;
    public Vector3 targetOffset;
    public void FixedUpdate()
    {
        ArmSolver.transform.position = Target.position + targetOffset;
        TimeFromLastShoot += Time.deltaTime;
        if (TimeFromLastShoot > TimeBtwShoots)
        {
            TimeFromLastShoot = 0;
            Shoot();
        }
    }
}
