using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [NonSerialized] public float speed;
    [NonSerialized] public char ch;

    private float tick;
    private IPObserver obs;

    // Start is called before the first frame update
    void Start()
    {
        obs = GameObject.Find("Main Camera").GetComponent<IPObserver>();
    }

    // Update is called once per frame
    void Update()
    {
        tick += Time.deltaTime;
        if (tick >= 1f / 60f)
        {
            tick = 0f;
            transform.Translate(0.0f, speed, 0.0f);
            if (transform.position.y > 5.2f)
            {
                obs.AddBul(ch);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("EBullet"))
        {
            Destroy(collision.gameObject);
            obs.AddBul(ch);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag.Equals("Enemy"))
        {
            if (!collision.gameObject.GetComponent<IPEnemyController>().toDestroy)
            {
                collision.gameObject.GetComponent<IPEnemyController>().Hit();
                obs.AddBul(ch);
                Destroy(this.gameObject);
            }
        }
    }
}
