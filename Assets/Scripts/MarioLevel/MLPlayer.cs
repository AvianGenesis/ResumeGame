using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLPlayer : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRight()
    {
        Debug.Log("Right");
        rb.AddForce(new Vector2(100.0f, 0.0f));
    }

    void OnLeft()
    {

    }

    void OnUp()
    {
        
    }
}
