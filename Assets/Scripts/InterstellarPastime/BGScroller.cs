using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    private float step;
    private Vector2 start;
    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {
        step = 0.0f;
        start = new Vector2(transform.localPosition.x, transform.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        step += speed * Time.deltaTime;
        if(step >= 1.0f)
        {
            step = 0.0f;
        }
        transform.localPosition = Vector2.Lerp(start, new Vector2(0.0f, start.y + -450.0f), step);
    }
}
