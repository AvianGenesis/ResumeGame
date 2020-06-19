using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPPlayerController : MonoBehaviour
{
    private bool holdR;
    private bool holdL;
    private bool holdU;
    private bool holdD;
    private Rigidbody2D rb;
    private Vector2 force;
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        holdR = false;
        holdL = false;
        holdU = false;
        holdD = false;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        force = Vector2.zero;
        if (holdR)
        {
            force += new Vector2(2.0f, 0.0f);
        }
        if (holdL)
        {
            force += new Vector2(-2.0f, 0.0f);
        }
        if (holdU)
        {
            force += new Vector2(0.0f, 2.0f);
        }
        if (holdD)
        {
            force += new Vector2(0.0f, -2.0f);
        }
        rb.velocity = force;
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
        GameObject newBul = Instantiate(bullet);
        newBul.transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
    }
}
