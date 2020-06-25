using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPObserver : MonoBehaviour
{
    [NonSerialized] public int points;
    [NonSerialized] public int bulCount;

    private int level;
    private int buffTick;
    private int flatBuff;
    private int hp;
    [SerializeField] private GameObject enemyObj;
    [SerializeField] private GameObject[] livesObj;
    [SerializeField] private GameObject[] bulletsObj;
    [SerializeField] private IPPlayerController playerCon;

    // Start is called before the first frame update
    void Start()
    {
        bulCount = 1;
        hp = 3;
        StartLevel(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel(int level)
    {
        buffTick = (level - 1) % 5;
        flatBuff = Mathf.FloorToInt((level - 1) / 5.0f);
        for(int i = 0; i <= hp - 2; i++)
        {
            livesObj[i].SetActive(true);
        }
        for (int i = 0; i <= bulCount - 1; i++)
        {
            bulletsObj[i].SetActive(true);
        }
        GameObject curMob;
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 11; j++)
            {
                curMob = Instantiate(enemyObj);
                curMob.transform.position = new Vector2(-5.0f + j, 4.0f - i);
                curMob.GetComponent<IPEnemyController>().Initialize(buffTick > 0 ? flatBuff + 2 : flatBuff + 1);
            }
            buffTick--;
        }
    }

    public void Hit()
    {
        hp--;
        livesObj[hp - 1].SetActive(false);
        if(hp <= 0)
        {
            //end game
        }
    }

    public void OneUp()
    {
        hp++;
        livesObj[hp - 2].SetActive(true);
    }

    public void AddScore(int toAdd)
    {
        points += toAdd;
        //end game if all enemies dead
    }

    public void AddBul()
    {
        //highlight bullet graphic
        bulCount++;
        bulletsObj[bulCount - 1].SetActive(true);
    }

    public void SubBul()
    {
        bulCount--;
        bulletsObj[bulCount].SetActive(false);
    }
}
