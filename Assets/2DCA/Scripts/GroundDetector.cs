using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = transform.parent.GetComponent<PlayerController>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            pc.EnterGround();
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            pc.ExitGround();
        }
    }
}
