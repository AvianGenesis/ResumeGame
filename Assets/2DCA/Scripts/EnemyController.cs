using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private AttackClass hitBy;
    private Vector2 velToSet;

    public float hp;
    public float fTick;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fTick -= Time.deltaTime;
        if(fTick <= 0.0f && rb.constraints == RigidbodyConstraints2D.FreezeAll)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = velToSet;
        }
    }

    public void Hit(AttackClass atk, string dir)
    {
        hitBy = atk;
        hp -= hitBy.damage;
        fTick = 0.1f;
        velToSet = new Vector2(hitBy.knockback.x * (dir == "r" ? 1.0f : -1.0f), hitBy.knockback.y);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
