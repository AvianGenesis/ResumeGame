using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IPPlayerController : MonoBehaviour
{
    private int uShotLevel;
    private float tick;
    private float speed;
    private float charge;
    private float uShotP;
    private bool holdR;
    private bool holdL;
    private bool holdU;
    private bool holdD;
    private bool holdS;
    private bool holdB;
    private bool holdQ;
    private bool canShoot;
    private GameObject shield;
    private GameObject beam;
    private Rigidbody2D rb;
    private Vector3 toAdd;
    private IPObserver obs;
    [SerializeField] private GameObject bullet;
    [SerializeField] private UShotUI uShotUI;

    // Start is called before the first frame update
    void Start()
    {
        uShotLevel = 0;
        speed = 0.07f;
        charge = 0.0f;
        uShotP = 0.0f;
        holdR = false;
        holdL = false;
        holdU = false;
        holdD = false;
        holdS = false;
        holdB = false;
        holdQ = false;
        canShoot = false;
        shield = transform.GetChild(0).gameObject;
        beam = transform.GetChild(1).gameObject;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        obs = GameObject.Find("Main Camera").GetComponent<IPObserver>();
    }

    // Update is called once per frame
    void Update()
    {
        tick += Time.deltaTime;
        if (tick >= 1f / 60f)
        {
            tick = 0;
            toAdd = Vector3.zero;
            if (holdR && transform.position.x < 5.6f)
            {
                toAdd += new Vector3(speed, 0.0f);
            }
            if (holdL && transform.position.x > -5.6f)
            {
                toAdd += new Vector3(-speed, 0.0f);
            }
            if (holdU && transform.position.y < -2.3f)
            {
                toAdd += new Vector3(0.0f, speed);
            }
            if (holdD && transform.position.y > -3.8f)
            {
                toAdd += new Vector3(0.0f, -speed);
            }
            transform.Translate(toAdd);
            shield.SetActive(false);

            if (holdS)
            {
                charge++;


                if (canShoot)
                {
                    canShoot = false;
                    if (obs.bulL && obs.tShot)
                    {
                        obs.SubBul('L');
                        GameObject newBul = Instantiate(bullet);
                        newBul.GetComponent<BulletController>().speed = 0.12f;
                        newBul.GetComponent<BulletController>().ch = 'L';
                        newBul.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 0.045f);
                    }

                    if (obs.bulM)
                    {
                        obs.SubBul('M');
                        GameObject newBul = Instantiate(bullet);
                        newBul.GetComponent<BulletController>().speed = 0.12f;
                        newBul.GetComponent<BulletController>().ch = 'M';
                        newBul.transform.position = new Vector2(transform.position.x, transform.position.y + 0.13f);
                    }

                    if (obs.bulR && obs.tShot)
                    {
                        obs.SubBul('R');
                        GameObject newBul = Instantiate(bullet);
                        newBul.GetComponent<BulletController>().speed = 0.12f;
                        newBul.GetComponent<BulletController>().ch = 'R';
                        newBul.transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y + 0.045f);
                    }
                }

                if (obs.uShot)
                {
                    if (uShotLevel == 0)
                    {
                        uShotP += 1.0f / 60.0f;
                    }
                    else if (uShotLevel == 1)
                    {
                        uShotP += 1.0f / 120.0f;
                    }
                    else if (uShotLevel == 2)
                    {
                        uShotP += 1.0f / 150.0f;
                    }


                    if (uShotP >= 1.0f)
                    {
                        uShotP = 0.0f;
                        uShotLevel++;
                        uShotUI.SetLevel(uShotLevel);
                    }
                    else if (uShotLevel != 3)
                    {
                        uShotUI.UpdateBar(uShotP);
                    }
                }
            }

            if (!holdS && obs.uShot)
            {
                if (uShotLevel > 0)
                {
                    UltiShot(uShotLevel);
                }
                uShotP = 0.0f;
                uShotLevel = 0;
                uShotUI.SetLevel(0);
            }

            if (holdQ && obs.shield && (obs.power >= 1.0f || obs.isDraining))
            {
                obs.Drain();
                obs.isDraining = true;
                obs.power -= 1.0f / 150.0f;
                shield.SetActive(true);
            }

            if (holdB && obs.beam && (obs.power >= 1.0f || obs.isDraining))
            {
                obs.Drain();
                obs.isDraining = true;
                obs.power -= 1.0f / 60.0f;
                beam.SetActive(true);
            }

            if (!canShoot && !holdS)
            {
                canShoot = true;
                obs.isDraining = false;
                shield.SetActive(false);
            }
            else if ((!holdB && !holdQ) || obs.power <= 0.0f)
            {
                obs.isDraining = false;
                beam.SetActive(false);
            }
        }
    }

    private void UltiShot(int lvl)
    {
        if(lvl == 1)
        {
            for(int i = 0; i < 5; i++)
            {
                GameObject newBul = Instantiate(bullet);
                newBul.GetComponent<BulletController>().speed = 0.12f;
                newBul.transform.position = new Vector2(transform.position.x + Mathf.Lerp(-0.3f, 0.3f, i / 4.0f), transform.position.y + 0.13f);
            }
        }
        else if (lvl == 2)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject newBul = Instantiate(bullet);
                newBul.GetComponent<BulletController>().speed = 0.12f;
                newBul.transform.position = new Vector2(transform.position.x + Mathf.Lerp(-0.3f, 0.3f, i / 7.0f), transform.position.y + 0.13f);
            }
        }
        else if (lvl == 3)
        {
            for (int i = 0; i < 12; i++)
            {
                GameObject newBul = Instantiate(bullet);
                newBul.GetComponent<BulletController>().speed = 0.12f;
                newBul.transform.position = new Vector2(transform.position.x + Mathf.Lerp(-0.3f, 0.3f, i / 11.0f), transform.position.y + 0.13f);
            }
        }
    }


    void OnRight(InputValue value)
    {
        holdR = value.Get<float>() == 1;
    }

    void OnLeft(InputValue value)
    {
        holdL = value.Get<float>() == 1;
    }

    void OnUp(InputValue value)
    {
        holdU = value.Get<float>() == 1;
    }
    void OnDown(InputValue value)
    {
        holdD = value.Get<float>() == 1;
    }

    void OnJump(InputValue value)
    {
        holdS = value.Get<float>() == 1;
    }

    void OnBeam(InputValue value)
    {
        holdB = value.Get<float>() == 1;
    }

    void OnShield(InputValue value)
    {
        holdQ = value.Get<float>() == 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("EBullet"))
        {
            Destroy(collision.gameObject);
            obs.Hit();
            ResetPos();
        }
        else if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<IPEnemyController>().Hit();
            obs.Hit();
            ResetPos();
        }
    }

    public void ResetPos()
    {
        transform.position = new Vector2(0.0f, -3.7f);
    }

    public void ResetChar()
    {
        holdR = false;
        holdL = false;
        holdU = false;
        holdD = false;
        holdS = false;
        holdB = false;
        holdQ = false;
    }
}
