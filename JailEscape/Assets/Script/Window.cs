using UnityEngine;

public class Window : MonoBehaviour
{
    public ParticleSystem OnDestroyEffect;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "JailMan")
            Destroy(gameObject);
    }
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.name == "JailMan")
    //        Destroy(gameObject);
    //}

    public void OnDestroy()
    {
        var quaternion = Quaternion.identity;
        quaternion.x = 197.43f;
        quaternion.y = -90f;
        quaternion.z = 90f;
        var pos = transform.position;
        Instantiate(OnDestroyEffect, pos, quaternion);
    }
}
