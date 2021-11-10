using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem walkParts, landPartsL, landPartsR, jumpParts, jumpPartsB;
    public GameObject camTarget, lockObj, lockRet;
    public GameObject hitbox;
    public Animation anim01;
    public AttackClass curMove;
    public float jumpForce;
    public float speed;
    public float hangTime;
    public float jumpBufferTime;

    private Rigidbody2D rb;
    private ParticleSystem.EmissionModule walkEmission, jumpEmission;
    private ParticleSystem.MainModule landEmissionL, landEmissionR;
    private CamController cam;
    private MoveList moveList;
    private SpriteRenderer sprite;
    private Queue<(string, float)> inputQ = new Queue<(string, float)>();
    private Vector2 input;
    private Vector2 prevVel;
    private Vector2 startLoc, lockLoc;
    private string atkBuffer;
    private float hangCounter;
    private float jumpBufferCounter;
    private float moveStateTick;
    private float hitEnd;
    private int atkState; // 0 = not attacking; 1 = startup; 2 = attacking; 3 = recovery; 4 = waiting
    private int moveDir;
    private bool isGrounded;
    private bool isLockedOn;
    private bool isPressJump;
    private bool isAttacking;

    void Start()
    {
        hitbox.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<CamController>();
        walkEmission = walkParts.emission;
        jumpEmission = jumpParts.emission;
        landEmissionL = landPartsL.main;
        landEmissionR = landPartsR.main;
        moveList = GetComponent<MoveList>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        startLoc = camTarget.transform.localPosition;
        moveDir = 0;
        isGrounded = false;
        isLockedOn = false;
        isPressJump = false;
        isAttacking = false;

        cam.target = camTarget.transform;
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) < 12.0f * (1.0f - 0.5f * (isLockedOn ? 1 : 0)) && atkState == 0)
        {
            rb.AddForce(new Vector2(input.x * speed * (isGrounded ? 1.0f : 0.5f), 0.0f));
        }
    }

    void Update()
    {
        /* Control particles and movement based on isGrounded */
        if (isGrounded)
        {
            walkEmission.rateOverTime = Mathf.Abs(rb.velocity.x) / 12.0f * 95.0f;
            hangCounter = hangTime;
            if(jumpBufferCounter > 0.0f) // Jump input buffer controller
            {
                Jump();
                if (isLockedOn)
                {
                    transform.rotation = new Quaternion(0.0f,
                                                        LockLookDir() < 0.0f ? 180.0f : 0.0f,
                                                        0.0f,
                                                        0.0f);
                }
                if (!isPressJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                }
            }
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }
        jumpBufferCounter -= Time.deltaTime;
        jumpEmission.rateOverTime = 60.0f * ((rb.velocity.y - 5.0f) / 8.0f);
        prevVel = rb.velocity;

        /* Control camera position and look direction while locked on */
        if (isLockedOn)
        {
            camTarget.transform.position = (transform.position + lockObj.transform.position) * 0.5f;
        }

        /* Control player while attacking */
        if(atkState > 0)
        {
            switch (atkState){
                case 1:
                    //play animation or something
                    break;
                case 2:
                    //trigger hitbox
                    break;
                case 3:
                    //play animation, check in onAttack if next move is triggered
                    break;
                case 4:
                    //continue prev animation
                    break;
            }

            moveStateTick -= Time.deltaTime;
            if(moveStateTick <= 0.0f)
            {
                if (atkState == 4)
                {
                    atkState = 0;
                    curMove = null;
                    UpdateLook();
                    sprite.color = new Color(255, 255, 255);
                }
                else
                {
                    atkState++;
                    switch (atkState)
                    {
                        case 2:
                            moveStateTick = curMove.atkTime;
                            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                            rb.velocity = new Vector2(curMove.playerVel.x * LockLookDir(), curMove.playerVel.y);
                            rb.position += curMove.moveDistance * Mathf.Sign(LockLookDir());
                            hitbox.SetActive(true);
                            hitbox.transform.localPosition = new Vector2(curMove.hitbox.x, curMove.hitbox.y);
                            hitbox.transform.localScale = new Vector2(curMove.hitbox.z, curMove.hitbox.w);
                            sprite.color = new Color(255, 0, 0);
                            break;
                        case 3:
                            moveStateTick = curMove.recovery;
                            hitEnd = Time.time;
                            hitbox.SetActive(false);
                            sprite.color = new Color(0, 255, 0);
                            break;
                        case 4:
                            moveStateTick = curMove.walkTime;
                            if (atkBuffer == "atk")
                            {
                                Attack();
                            }
                            else
                            {
                                sprite.color = new Color(0, 0, 255);
                                if(atkBuffer == "jump" && isGrounded)
                                {
                                    Jump();
                                }
                            }
                            break;
                        default:
                            Debug.LogError("Unplanned atkState: " + atkState);
                            break;
                    }
                }
            }
        }

        if(inputQ.Count > 0 && Time.time - inputQ.Peek().Item2 >= 0.3f)
        {
            Debug.Log(inputQ.Count);
            Debug.Log(inputQ.Dequeue());
        }
    }

    private void Jump()
    {
        inputQ.Enqueue(("j", Time.time));
        jumpBufferCounter = -1.0f;
        if (input.x > 0 && rb.velocity.x >= 0.0f || input.x < 0 && rb.velocity.x <= 0.0f) // If you jump in direction of movement, instant max speed
        {
            jumpPartsB.Emit((int)(20 * (Mathf.Abs((Mathf.Abs(rb.velocity.x) - 12.0f) - 3.0f) / 9.0f)) - 6);
            //rb.velocity = new Vector2(rb.velocity.x + (12.0f - Mathf.Abs(rb.velocity.x)) * input.x, jumpForce);
            rb.velocity = new Vector2(12.0f * input.x * (isLockedOn ? 0.5f : 1.0f), jumpForce);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        walkEmission.enabled = false;
        jumpEmission.enabled = true;
    }

    // Update look when not locked on (point in direction of input): atkState = 0 & movement input read, atkState ticks to 0 & movement input pressed, land & movement input pressed, attack, attacked (towards attacker)(animation?)
    // Update look when locked on (point towards enemy): atkState = 0 & movement input read, atkState ticks to 0 & movement input pressed, attack, attacked (towards attack, not target)(animation?)
    private void UpdateLook()
    {
        if (isLockedOn)
        {
            transform.rotation = new Quaternion(0.0f,
                                                LockLookDir() < 0.0f ? 180.0f : 0.0f,
                                                0.0f,
                                                0.0f);
        }
        else if (moveDir != 0)
        {
            transform.rotation = new Quaternion(0.0f, 90.0f - 90.0f * moveDir, 0.0f, 0.0f);
        }
    }

    private void Attack()
    {
        if(isLockedOn && !isGrounded && inputQ.Count >= 2 && inputQ.ToArray()[inputQ.Count - 1].Item1 == "f" && inputQ.ToArray()[inputQ.Count - 2].Item1 == "b") // Aerial back -> forward
        {
            curMove = moveList.amDash;
        }
        else if (isLockedOn && isGrounded && moveDir * LockLookDir() == -1) // Grounded hold back
        {
            curMove = moveList.ghLauncher;
        }
        else if(curMove != null)
        {
            if (curMove.grounded == isGrounded && curMove.nextWait != null && Time.time - hitEnd >= curMove.recovery + 0.1f)
            {
                curMove = curMove.nextWait;
            }
            else if (curMove.grounded == isGrounded && curMove.nextNorm != null)
            {
                curMove = curMove.nextNorm;
            }
            else
            {
                if (isGrounded)
                {
                    curMove = moveList.gMash01;
                }
                else
                {
                    curMove = moveList.aMash01;
                }
            }
        }
        else
        {
            if (isGrounded)
            {
                curMove = moveList.gMash01;
            }
            else
            {
                curMove = moveList.aMash01;
            }
        }
        atkState = 1;
        atkBuffer = "";
        inputQ.Clear();
        rb.velocity = new Vector2(0.0f, 0.0f);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        sprite.color = new Color(255, 255, 0);
        moveStateTick = curMove.startup;
        UpdateLook();
    }

    private int LockLookDir()
    {
        int ret;
        ret = (int)Mathf.Sign(camTarget.transform.position.x - transform.position.x);
        return ret;
    }

    public void EnterGround()
    {
        isGrounded = true;
        walkEmission.enabled = true;
        landEmissionL.startSize = 0.34f * (-prevVel.y / 12.0f);
        landEmissionR.startSize = 0.34f * (-prevVel.y / 12.0f);
        landPartsL.Emit((int)(10 * ((-prevVel.y - 3) / 9.0f)));
        landPartsR.Emit((int)(10 * ((-prevVel.y - 3) / 9.0f)));
        if (moveDir != 0)
        {
            UpdateLook();
            Debug.Log("EnterGround()");
        }
    }

    public void ExitGround()
    {
        isGrounded = false;
        walkEmission.enabled = false;
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
        moveDir = (int)input.x;
        if (isGrounded && atkState == 0)
        {
            if (input.x == 1)
            {
                UpdateLook();
            }
            else if (input.x == -1)
            {
                UpdateLook();
            }
        }

        if (isLockedOn)
        {
            if (input.x != 0)
            {
                if(LockLookDir() == input.x)
                {
                    inputQ.Enqueue(("f", Time.time));
                }
                else
                {
                    inputQ.Enqueue(("b", Time.time));
                }
            }
            else if (input.y == 1)
            {
                inputQ.Enqueue(("u", Time.time));
            }
            else if (input.y == -1)
            {
                inputQ.Enqueue(("d", Time.time));
            }
        }
    }

    public void OnJump(InputValue value)
    {
        isPressJump = value.Get<float>() == 1;
        if (atkState == 0 || atkState == 4)
        {
            if (isPressJump)
            {
                jumpBufferCounter = jumpBufferTime;
                if (hangCounter > 0.0f) // If press jump after leaving platform in short time
                {
                    Jump();
                }
            }
            else if (rb.velocity.y > 0.0f && !isPressJump) // Reduce vertical vel on button release
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
        else if(atkState == 3 || atkState == 2)
        {
            atkBuffer = "jump";
        }
    }

    public void OnLockOn(InputValue value)
    {
        bool val = value.Get<float>() == 1;
        isLockedOn = val;
        cam.locked = val;
        if (val)
        {
            lockRet.SetActive(true);
        }
        else
        {
            lockRet.SetActive(false);
            camTarget.transform.localPosition = startLoc;
        }
    }

    public void OnAttack(InputValue value)
    {
        bool val = value.Get<float>() == 1;
        if (val)
        {
            switch (atkState)
            {
                case 0:
                    Attack();
                    break;
                case 1:
                    break;
                case 2:
                    atkBuffer = "atk";
                    break;
                case 3:
                    atkBuffer = "atk";
                    break;
                case 4:
                    Attack();
                    break;
                default:
                    break;
            }
        }
    }
}