using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody2D ammoPrefab;
    public float ammoSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
            createAmmo(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
            Destroy(collision.gameObject);

        }
    }

    private void Update()
    {
        if (transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }

    void createAmmo(float x, float y)
    {
        Rigidbody2D bulletRb;
        bulletRb = Instantiate(ammoPrefab, new Vector3(x, y, 3), Quaternion.identity);
        bulletRb.AddForce(Vector2.down * ammoSpeed);
    }
}
