using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float startx;
    public float starty;
    public int piecex;
    public int piecey;
    public float spacingx;
    public float spacingy;
    public GameObject EnemyPrefab;
    List<GameObject> liste;
    public Rigidbody2D EnemyBulletPrefab;
    public float EnemyBulletForce;
    public float timer;
    Rigidbody2D EnemyBulletRb;

    // Start is called before the first frame update
    void Start()
    {
        liste = new List<GameObject>();
        spawn();
        InvokeRepeating("fire", 1, timer);
    }

    private void Update()
    {

    }

    private void spawn()
    {
        for (float x = startx; x < startx + piecex * spacingx; x += spacingx)
        {
            for(float y = starty; y > starty - piecey *spacingy; y -= spacingy)
            {
                GameObject go = Instantiate(EnemyPrefab, new Vector2(x, y), Quaternion.identity);
                liste.Add(go);
            }
        }
    }

    private void EnemyFire(float x, float y)
    {
        EnemyBulletRb = Instantiate(EnemyBulletPrefab, new Vector3(x, y, 3), Quaternion.identity);
        EnemyBulletRb.AddForce(Vector2.down * EnemyBulletForce);
    }

    void fire()
    {
        if(liste.Count != 0)
        {
            int random = Random.Range(0, liste.Count);
            if (liste[random] != null)
            {
                Vector2 newPosition = liste[random].transform.position;
                EnemyFire(newPosition.x, newPosition.y);
            }
            else
            {
                liste.RemoveAt(random);
            }
        }
    }
}
