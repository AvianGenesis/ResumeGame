using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPBeam : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("EBullet"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<IPEnemyController>().Hit();
        }
    }
}
