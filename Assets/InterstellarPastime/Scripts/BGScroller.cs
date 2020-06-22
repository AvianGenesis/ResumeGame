using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.y <= -25.0f)
        {
            transform.localPosition = new Vector2(0.0f, 25.0f);
        }
        transform.localPosition = new Vector2(0.0f, transform.localPosition.y - speed);
    }
}
