using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPEnemyController : MonoBehaviour
{
    [NonSerialized] public int val;
    [NonSerialized] public int hp;

    private IPObserver obs;
    [SerializeField] private Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        obs = GameObject.Find("Main Camera").GetComponent<IPObserver>();
    }

    public void Initialize(int health)
    {
        hp = health;
        switch (hp)
        {
            case 1: val = 100;
                break;
            case 2: val = 250;
                break;
            case 3: val = 450;
                break;
            default: Debug.LogError("Invalid HP");
                break;
        }
        UpdateCol();
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
            return;
        }
        UpdateCol();
    }

    private void UpdateCol()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = colors[hp - 1];
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
