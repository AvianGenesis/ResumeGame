using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class IPObserver : MonoBehaviour
{
    [NonSerialized] public int points;
    [NonSerialized] public int bulCount;
    [NonSerialized] public char enemDir;

    private int bulMax;
    private int level;
    private int buffTick;
    private int flatBuff;
    private int speed;
    private int frameTick;
    private int hp;
    private int enemiesAlive;
    private int cooldown;
    private int shootRate;
    private char prevDir;
    private bool isPlay;
    private GameObject[,] enemies;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject moon;
    [SerializeField] private GameObject enemyObj;
    [SerializeField] private GameObject[] livesObj;
    [SerializeField] private GameObject[] bulletsObj;
    [SerializeField] private IPPlayerController playerCon;
    [SerializeField] private Button titleHL;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        bulCount = 1;
        bulMax = 1;
        speed = 90;
        frameTick = 0;
        hp = 3;
        cooldown = 0;
        shootRate = 30;
        isPlay = false;
        enemDir = 'r';
        prevDir = enemDir;
        enemies = new GameObject[5, 11];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                enemies[i,j] = Instantiate(enemyObj);
                enemies[i, j].SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (isPlay)
        {
            /* Move Enemies */
            frameTick++;
            if (frameTick >= speed)
            {
                frameTick = 0;
                if (enemDir != prevDir)
                {
                    prevDir = enemDir;
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 11; j++)
                        {
                            enemies[i, j].GetComponent<IPEnemyController>().MoveDown();
                        }
                    }
                }
                else if (enemDir == 'r')
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 11; j++)
                        {
                            enemies[i, j].GetComponent<IPEnemyController>().MoveRight();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 11; j++)
                        {
                            enemies[i, j].GetComponent<IPEnemyController>().MoveLeft();
                        }
                    }
                }
            }

            /* Trigger Shooting */
            cooldown++;
            if (cooldown >= shootRate)
            {
                while (cooldown != 0)
                {
                    int x = UnityEngine.Random.Range(0, 5);
                    int y = UnityEngine.Random.Range(0, 11);
                    if (enemies[x, y].activeSelf)
                    {
                        enemies[x, y].GetComponent<IPEnemyController>().Shoot();
                        cooldown = 0;
                    }
                }
            }
        }
    }

    /* Start Level */
    public void StartLevel(int level)
    {
        isPlay = true;
        buffTick = (level - 1) % 5;
        flatBuff = Mathf.FloorToInt((level - 1) / 5.0f);

        /* Set Active */
        for(int i = 0; i <= hp - 2; i++)
        {
            livesObj[i].SetActive(true);
        }
        for (int i = 0; i <= bulCount - 1; i++)
        {
            bulletsObj[i].SetActive(true);
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                enemies[i, j].SetActive(true);
                enemies[i, j].transform.position = new Vector2(-5.0f + j, 4.0f - i);
                enemies[i, j].GetComponent<IPEnemyController>().Initialize(buffTick > 0 ? flatBuff + 2 : flatBuff + 1);
            }
            buffTick--;
        }
        enemiesAlive = 55; //change to 56 when boss here?
        playerCon.gameObject.SetActive(true);
        moon.SetActive(false);
        playerCon.ResetPos();
    }

    /* End Level */
    private void EndLevel()
    {
        speed -= 5;
        for (int i = 0; i < livesObj.Length; i++)
        {
            livesObj[i].SetActive(false);
        }
        for (int i = 0; i < bulletsObj.Length; i++)
        {
            bulletsObj[i].SetActive(false);
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                enemies[i, j].SetActive(false);
            }
        }
        
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if(go.tag.Equals("Bullet") || go.tag.Equals("EBullet"))
            {
                Destroy(go);
            }
        }
        isPlay = false;
        playerCon.gameObject.SetActive(false);
        moon.SetActive(true);
    }

    /* When player Hit */
    public void Hit()
    {
        hp--;
        if(hp <= 0)
        {
            EndLevel();
            points = 0;
            title.SetActive(true);
            //titleHL.Select();
            return;
        }
        livesObj[hp - 1].SetActive(false);
    }

    public void OneUp()
    {
        hp++;
        livesObj[hp - 2].SetActive(true);
    }

    public void AddScore(int toAdd)
    {
        points += toAdd;
        enemiesAlive--;
        if(enemiesAlive == 0)
        {
            EndLevel();
            level++;
            shop.SetActive(true);
        }
    }

    public void AddBul()
    {
        //highlight bullet graphic
        bulCount++;
        if(bulCount > bulMax)
        {
            bulCount = bulMax;
        }
        bulletsObj[bulCount - 1].SetActive(true);
    }

    public void SubBul()
    {
        bulCount--;
        bulletsObj[bulCount].SetActive(false);
    }
}
