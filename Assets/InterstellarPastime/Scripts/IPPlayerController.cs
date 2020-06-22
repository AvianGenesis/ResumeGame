using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPPlayerController : MonoBehaviour
{
    [NonSerialized] public int bulCount;

    private float speed;
    private bool holdR;
    private bool holdL;
    private bool holdU;
    private bool holdD;
    private Rigidbody2D rb;
    private Vector3 toAdd;
    private IPObserver obs;
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.035f;
        bulCount = 1;
        holdR = false;
        holdL = false;
        holdU = false;
        holdD = false;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        obs = GameObject.Find("Main Camera").GetComponent<IPObserver>();
    }

    // Update is called once per frame
    void Update()
    {
        toAdd = Vector3.zero;
        if (holdR)
        {
            toAdd += new Vector3(speed, 0.0f);
        }
        if (holdL)
        {
            toAdd += new Vector3(-speed, 0.0f);
        }
        if (holdU)
        {
            toAdd += new Vector3(0.0f, speed);
        }
        if (holdD)
        {
            toAdd += new Vector3(0.0f, -speed);
        }
        transform.Translate(toAdd);
    }


    void OnRight()
    {
        Debug.Log("Right");
        holdR = !holdR;
    }

    void OnLeft()
    {
        Debug.Log("Left");
        holdL = !holdL;
    }

    void OnUp()
    {
        holdU = !holdU;
    }
    void OnDown()
    {
        holdD = !holdD;
    }

    void OnJump()
    {
        if (bulCount > 0)
        {
            bulCount--;
            GameObject newBul = Instantiate(bullet);
            newBul.GetComponent<BulletController>().speed = 0.06f;
            newBul.transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("EBullet"))
        {
            Destroy(collision.gameObject);
            obs.Hit();
            //reset pos
        }
    }
}
