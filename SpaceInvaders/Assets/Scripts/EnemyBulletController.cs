using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBulletController : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -6) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
