using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [NonSerialized] public float speed;

    private IPObserver obs;

    // Start is called before the first frame update
    void Start()
    {
        obs = GameObject.Find("Main Camera").GetComponent<IPObserver>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, speed, 0.0f);
        if(transform.position.y > 5.2f)
        {
            obs.AddBul();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("EBullet"))
        {
            Destroy(collision.gameObject);
            obs.AddBul();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<IPEnemyController>().Hit();
            obs.AddBul();
            Destroy(this.gameObject);
        }
    }
}
