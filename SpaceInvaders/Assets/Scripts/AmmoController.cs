using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    PlayerController pc;

    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            pc.addAmmo();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
