using UnityEngine;

public class EnemyWeaponController : WeaponController
{
    public string TargetName = "JailMan";
    public float maxDistanceToShootSqr = 20000f;
    public Vector3 targetOffset;

    private Transform Target;

    public void Awake()
    {
        if (Target == null)
            Target = GameObject.Find(TargetName).transform;
    }
    public void FixedUpdate()
    {
        var distToTarget = Mathf.Abs(transform.position.sqrMagnitude - Target.position.sqrMagnitude);
        if (distToTarget <= maxDistanceToShootSqr)
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
}
