using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPObserver : MonoBehaviour
{
    [NonSerialized] public int points;

    private int level;
    private int hp;
    [SerializeField] private GameObject enemyObj;
    [SerializeField] private IPPlayerController playerCon;

    // Start is called before the first frame update
    void Start()
    {
        StartLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel(int level)
    {
        GameObject curMob;
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 11; j++)
            {
                curMob = Instantiate(enemyObj);
                curMob.transform.position = new Vector2(-5.0f + j, 4.0f - i);
            }
        }
    }

    public void Hit()
    {
        Debug.Log("P Hit");
        hp--;
        if(hp <= 0)
        {
            //end game
        }
    }

    public void AddScore(int toAdd)
    {
        points += toAdd;
        //end game if all enemies dead
    }

    public void AddBul()
    {
        //highlight bullet graphic
        playerCon.bulCount++;
    }
}
