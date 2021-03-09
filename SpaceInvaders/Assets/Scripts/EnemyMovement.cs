using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float time;
    float timer = 0;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > time)
            timer = -time;

        if (timer > 0)
            rb.velocity = Vector2.left * speed;
        if (timer < 0)
            rb.velocity = Vector2.right * speed;
    }
}
