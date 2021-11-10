using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLPlayer : MonoBehaviour
{
    private bool holdR;
    private bool holdL;
    private bool holdU;
    private bool holdD;
    private Rigidbody2D rb;

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
        if (holdR)
        {
            rb.AddForce(new Vector2(10.0f, 0.0f));
        }
        if (holdL)
        {
            rb.AddForce(new Vector2(-10.0f, 0.0f));
        }
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
}
