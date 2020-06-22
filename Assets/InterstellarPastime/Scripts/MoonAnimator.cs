using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MoonAnimator : MonoBehaviour
{
    private float start;
    private float step;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        step = 0.0f;
        speed = Mathf.PI / 5.0f;
        start = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        step += speed * Time.deltaTime;
        transform.localPosition = new Vector2(0.0f, start + (Mathf.Cos(step) - 1.0f) * 7.5f);
    }
}
