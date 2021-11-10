using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [NonSerialized] public float speed;

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
            if (transform.position.y < -5.2f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
