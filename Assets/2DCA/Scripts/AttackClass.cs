using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackClass
{
    public AttackClass nextNorm, nextWait;
    public Animation anim;
    public AudioSource soundWhiff, soundHit; // Sounds if you miss/hit attack
    public Vector4 hitbox; //new Vector4(middle x, middle y, total width, total height)
    public Vector2 superArmor; // Between what time periods, if any, player gets super armor
    public Vector2 moveDistance; // Direction to move player discrete distance
    public Vector2 playerVel; // Velocity set to player during hitbox
    public Vector2 knockback; // Knockback power against enemy
    public string moveName; // Name of the move
    public bool grounded;
    public float damage;
    public float startup; // Time from button press to hitbox
    public float atkTime; // Time hitbox is out (0.0f = one frame)
    public float recovery; // Time from hitbox to next button press/jump
    public float walkTime; // Time from recovery end to walkability (attack between recovery and walkTime triggers nextWait attack)

    public AttackClass() { }

    /*
    public AttackClass(Vector4 hb, float su, float rc, float wt)
    {
        hitbox = hb;
        startup = su;
        recovery = rc;
        walkTime = wt;
    }
    */
}
