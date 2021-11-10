using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
    public bool locked;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (locked)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.position.x, 10f * Time.deltaTime),
                                             Mathf.Lerp(transform.position.y, target.position.y, 10f * Time.deltaTime),
                                             transform.position.z);
        }
        else
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.position.x, 5f * Time.deltaTime),
                                             Mathf.Lerp(transform.position.y, target.position.y, 5f * Time.deltaTime),
                                             transform.position.z);
        }
    }
}