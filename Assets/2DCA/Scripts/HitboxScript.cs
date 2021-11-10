using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = transform.parent.GetComponent<PlayerController>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            EnemyController ec = col.gameObject.GetComponent<EnemyController>();
            ec.Hit(pc.curMove, transform.parent.transform.rotation.y == 0.0f ? "r" : "l");
        }
    }
}
