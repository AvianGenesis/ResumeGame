using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPEnemyController : MonoBehaviour
{
    [NonSerialized] public int val;
    [NonSerialized] public int hp;

    private IPObserver obs;

    // Start is called before the first frame update
    void Start()
    {
        obs = GameObject.Find("Main Camera").GetComponent<IPObserver>();
    }

    public void CreateEnemy(int health)
    {
        hp = health;
    }

    public void Hit()
    {
        hp--;
        if(hp <= 0)
        {
            obs.AddScore(val);
            Destroy(this.gameObject);
        }
    }

    public void MoveRight()
    {
        transform.Translate(0.2f, 0.0f, 0.0f);
    }

    public void MoveLeft()
    {
        transform.Translate(-0.2f, 0.0f, 0.0f);
    }

    public void MoveUp()
    {
        transform.Translate(0.0f, 0.2f, 0.0f);
    }

    public void MoveDown()
    {
        transform.Translate(0.0f, -0.2f, 0.0f);
    }
}
