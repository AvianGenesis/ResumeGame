using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimator : MonoBehaviour
{
    public float rotSpeed;
    public float rotEdges;

    private float tick;
    private RectTransform rt;
    private Vector3 startRot;

    // Start is called before the first frame update
    void Start()
    {
        tick = 0.0f;
        rt = GetComponent<RectTransform>();
        startRot = rt.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        tick += rotSpeed * Time.deltaTime;
        rt.eulerAngles = new Vector3(startRot.x, startRot.y, startRot.z + Mathf.Sin(tick) * rotEdges);
    }
}
