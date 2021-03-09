using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float BulletForce;
    public float speed;
    float horizontal;
    Rigidbody2D rb;
    public Rigidbody2D bulletPrefab;
    int ammo = 1;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("space") && ammo == 1)
        {
            Rigidbody2D bulletRb;
            bulletRb = Instantiate(bulletPrefab, new Vector3(transform.position.x,transform.position.y,3), Quaternion.identity);
            bulletRb.AddForce(Vector2.up * BulletForce);
            ammo --;
        }
        if (ammo == 1)
        {
            sr.color = Color.green;
        }
        else sr.color = Color.red;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, 0) * speed * Time.deltaTime;
    }
    public void addAmmo()
    {
        ammo++;
    }
}
