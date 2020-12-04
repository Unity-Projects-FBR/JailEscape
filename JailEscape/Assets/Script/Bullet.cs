using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 800f;
    public int damage = 10;

    // Start is called before the first frame update
    public void Start()
    {
        var rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * -bulletSpeed;
    }

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.TryGetComponent<Health>(out Health healthObject))
        {
            healthObject.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
