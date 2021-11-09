using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class IPObserver : MonoBehaviour
{
    [NonSerialized] public int points;
    [NonSerialized] public float power;
    [NonSerialized] public char enemDir;
    [NonSerialized] public bool isDraining;
    [NonSerialized] public bool bulL;
    [NonSerialized] public bool bulM;
    [NonSerialized] public bool bulR;
    [NonSerialized] public bool tShot;
    [NonSerialized] public bool shield;
    [NonSerialized] public bool beam;
    [NonSerialized] public bool uShot;

    private int level;
    private int rows;
    private int cols;
    private int buffTick;
    private int flatBuff;
    private int speed;
    private int frameTick;
    private int hp;
    private int enemiesAlive;
    private int cooldown;
    private int shootRate;
    private float pBarStart;
    private float pBarTick;
    private char prevDir;
    private bool isPlay;
    private GameObject[,] enemies;
    private Slider pBarSlider;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject tShotObj;
    [SerializeField] private GameObject shieldObj;
    [SerializeField] private GameObject beamObj;
    [SerializeField] private GameObject uShotObj;
    [SerializeField] private GameObject uShotHUD;
    [SerializeField] private GameObject moon;
    [SerializeField] private GameObject enemyObj;
    [SerializeField] private GameObject pBar;
    [SerializeField] private GameObject barReady;
    [SerializeField] private GameObject[] livesObj;
    [SerializeField] private IPPlayerController playerCon;
    [SerializeField] private Button titleHL;
    [SerializeField] private Color gray;
    [SerializeField] private Text pointsText;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        points = 0;
        level = 1;
        rows = 5;
        cols = 11;
        speed = 90;
        frameTick = 0;
        hp = 3;
        cooldown = 0;
        shootRate = 30;
        power = 0.0f;
        pBarStart = pBar.transform.position.y;
        pBarTick = 0.0f;
        isPlay = false;
        enemDir = 'r';
        prevDir = enemDir;
        bulL = true;
        bulM = true;
        bulR = true;
        tShot = false;
        shield = false;
        beam = false;
        uShot = false;
        enemies = new GameObject[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                enemies[i,j] = Instantiate(enemyObj);
                enemies[i,j].SetActive(false);
            }
        }
        pBarSlider = pBar.GetComponent<Slider>();
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
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            enemies[i, j].GetComponent<IPEnemyController>().MoveDown();
                        }
                    }
                }
                else if (enemDir == 'r')
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            enemies[i, j].GetComponent<IPEnemyController>().MoveRight();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
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
                    int x = UnityEngine.Random.Range(0, rows);
                    int y = UnityEngine.Random.Range(0, cols);
                    if (enemies[x, y].activeSelf)
                    {
                        enemies[x, y].GetComponent<IPEnemyController>().Shoot();
                        cooldown = 0;
                    }
                }
            }

            /* Incr Power */
            if (shield || beam)
            {
                if (power < 1.0f && !isDraining)
                {
                    power += 1.0f / 600.0f;
                }
                else if (power < 0.0f)
                {
                    isDraining = false;
                }
                else if (power >= 1.0f)
                {
                    pBarTick += (float)Math.PI / 60.0f;
                    pBar.transform.position = new Vector2(pBar.transform.position.x, pBarStart + (float)Math.Sin(pBarTick) * 2.0f);
                    barReady.SetActive(true);
                }
                pBarSlider.value = power;
            }
        }
    }

    /* Start Level */
    public void StartLevel()
    {
        isPlay = true;
        buffTick = (level - 1) % 5;
        flatBuff = Mathf.FloorToInt((level - 1) / 5.0f);

        /* Set Active */
        for(int i = 0; i <= hp - 2; i++)
        {
            livesObj[i].SetActive(true);
        }
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                enemies[i, j].SetActive(true);
                enemies[i, j].transform.position = new Vector2(-5.0f + j, 4.0f - i);
                enemies[i, j].GetComponent<IPEnemyController>().Initialize(buffTick > 0 ? flatBuff + 2 : flatBuff + 1);
            }
            buffTick--;
        }
        pointsText.gameObject.SetActive(true);
        if(shield || beam)
        {
            pBar.SetActive(true);
        }
        if (uShot)
        {
            uShotHUD.SetActive(true);
        }
        enemiesAlive = rows * cols; //change to 56 when boss here?
        pBarSlider.value = 0.0f;
        playerCon.gameObject.SetActive(true);
        shop.SetActive(false);
        moon.SetActive(false);
        playerCon.ResetPos();
    }

    /* End Level */
    private void EndLevel()
    {
        isPlay = false;
        speed -= 5;
        for (int i = 0; i < livesObj.Length; i++)
        {
            livesObj[i].SetActive(false);
        }
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                enemies[i, j].SetActive(false);
            }
        }
        pBar.SetActive(false);
        
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if(go.tag.Equals("Bullet") || go.tag.Equals("EBullet"))
            {
                Destroy(go);
            }
        }
        uShotHUD.SetActive(false);
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
            hp = 3;
            title.SetActive(true);
            pointsText.gameObject.SetActive(false);
            return;
        }
        livesObj[hp - 1].SetActive(false);
    }

    public void Drain()
    {
        barReady.SetActive(false);
    }

    /*********************/
    /* Shop Interactions */
    /*********************/
    public void GetTShot()
    {
        if (points >= 3000)
        {
            AddScore(-3000);
            tShot = true;
            tShotObj.GetComponent<Image>().color = gray;
            tShotObj.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void GetShield()
    {
        if (points >= 3500)
        {
            AddScore(-3500);
            shield = true;
            shieldObj.GetComponent<Image>().color = gray;
            shieldObj.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void GetBeam()
    {
        if (points >= 5000)
        {
            AddScore(-5000);
            beam = true;
            beamObj.GetComponent<Image>().color = gray;
            beamObj.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void GetUShot()
    {
        if (points >= 7500)
        {
            AddScore(-7500);
            uShot = true;
            uShotObj.GetComponent<Image>().color = gray;
            uShotObj.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    /* Misc */
    public void OneUp()
    {
        hp++;
        livesObj[hp - 2].SetActive(true);
    }

    /* Add Score & Check Enem Count */
    public void AddScore(int toAdd)
    {
        points += toAdd;
        pointsText.text = "Points: " + points;
        if(AllDead() && !shop.activeSelf)
        {
            EndLevel();
            level++;
            OneUp();
            shop.SetActive(true);
        }
    }

    private bool AllDead()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (enemies[i,j].activeSelf)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void AddBul(char ch)
    {
        switch (ch)
        {
            case ('L'):
                bulL = true;
                break;
            case ('M'):
                bulM = true;
                break;
            case ('R'):
                bulR = true;
                break;
            default:
                break;
        }
    }

    public void SubBul(char ch)
    {
        switch (ch)
        {
            case ('L'):
                bulL = false;
                break;
            case ('M'):
                bulM = false;
                break;
            case ('R'):
                bulR = false;
                break;
            default:
                break;
        }
    }
}
