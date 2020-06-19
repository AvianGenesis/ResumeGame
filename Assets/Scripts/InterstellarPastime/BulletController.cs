using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 6.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
