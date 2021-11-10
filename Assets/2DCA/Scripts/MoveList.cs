using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveList : MonoBehaviour
{
    public AttackClass gMash01, gMash02, gMash03, gMash04F, ghLauncher, gwBladeGrab, gwGolfSwing;
    public AttackClass aMash01, aMash02, aMash03F, awLauncher02F, awLauncher01, amDash;

    private void Awake()
    {
        /* Create Moves */
        gMash01 = new AttackClass()
        {
            hitbox = new Vector4(1.0f, 0.0f, 1.0f, 0.5f),
            moveDistance = new Vector2(0.25f, 0.0f),
            playerVel = new Vector2(0.0f, 0.0f),
            knockback = new Vector2(2.0f, 2.0f),
            moveName = "GroundMash01",
            grounded = true,
            damage = 1.0f,
            startup = 0.1f,
            atkTime = 0.025f,
            recovery = 0.25f,
            walkTime = 0.2f,
            // Etc...
        };
        gwBladeGrab = new AttackClass()
        {
            hitbox = new Vector4(1.0f, 0.0f, 1.0f, 1.0f),
            moveDistance = new Vector2(-0.1f, 0.0f),
            playerVel = new Vector2(0.0f, 0.0f),
            knockback = new Vector2(-0.5f, 3.0f),
            moveName = "BladeGrab",
            grounded = true,
            damage = 1.0f,
            startup = 0.1f,
            atkTime = 0.075f,
            recovery = 0.15f,
            walkTime = 0.4f,
            // Etc...
        };
        gwGolfSwing = new AttackClass()
        {
            hitbox = new Vector4(0.75f, -0.15f, 1.5f, 1.0f),
            moveDistance = new Vector2(0.2f, 0.0f),
            playerVel = new Vector2(0.0f, 0.0f),
            knockback = new Vector2(8.0f, 6.0f),
            moveName = "GolfSwing",
            grounded = true,
            damage = 1.0f,
            startup = 0.3f,
            atkTime = 0.1f,
            recovery = 0.15f,
            walkTime = 0.2f,
            // Etc...
        };
        gMash02 = new AttackClass()
        {
            hitbox = new Vector4(1.0f, 0.0f, 1.0f, 0.5f),
            moveDistance = new Vector2(0.25f, 0.0f),
            playerVel = new Vector2(0.0f, 0.0f),
            knockback = new Vector2(2.0f, 2.0f),
            moveName = "GroundMash02",
            grounded = true,
            damage = 1.0f,
            startup = 0.1f,
            atkTime = 0.025f,
            recovery = 0.25f,
            walkTime = 0.1f,
            // Etc...
        };
        gMash03 = new AttackClass()
        {
            hitbox = new Vector4(1.0f, 0.05f, 1.0f, 1.1f),
            moveDistance = new Vector2(0.35f, 0.0f),
            playerVel = new Vector2(0.0f, 0.0f),
            knockback = new Vector2(2.0f, 2.0f),
            moveName = "GroundMash03F",
            grounded = true,
            damage = 2.0f,
            startup = 0.1f,
            atkTime = 0.1f,
            recovery = 0.35f,
            walkTime = 0.2f,
            // Etc...
        };
        gMash04F = new AttackClass()
        {
            hitbox = new Vector4(1.15f, 0.05f, 1.3f, 1.1f),
            moveDistance = new Vector2(0.45f, 0.0f),
            playerVel = new Vector2(0.0f, 0.0f),
            knockback = new Vector2(4.5f, 4.5f),
            moveName = "GroundMash03F",
            grounded = true,
            damage = 2.0f,
            startup = 0.4f,
            atkTime = 0.125f,
            recovery = 0.45f,
            walkTime = 0.3f,
            // Etc...
        };
        gMash01.nextNorm = gMash02;
        gMash02.nextNorm = gMash03;
        gMash03.nextNorm = gMash04F;
        gMash01.nextWait = gwBladeGrab;
        gwBladeGrab.nextNorm = gwGolfSwing;

        ghLauncher = new AttackClass()
        {
            hitbox = new Vector4(1.0f, -1.0f, 1.0f, 2.0f),
            moveDistance = new Vector2(0.0f, 0.0f),
            playerVel = new Vector2(0.0f, 20.0f),
            knockback = new Vector2(0.5f, 21.0f),
            moveName = "LaunchEnemyF",
            grounded = true,
            damage = 2.0f,
            startup = 0.1f,
            atkTime = 0.2f,
            recovery = 0.15f,
            walkTime = 0.1f,
        };

        aMash01 = new AttackClass()
        {
            hitbox = new Vector4(1.5f, 0.0f, 1.5f, 1.0f),
            moveDistance = new Vector2(0.0f, 0.0f),
            playerVel = new Vector2(0.0f, 7.5f),
            knockback = new Vector2(0.0f, 6.0f),
            moveName = "AirMash01",
            grounded = false,
            damage = 1.0f,
            startup = 0.05f,
            atkTime = 0.05f,
            recovery = 0.25f,
            walkTime = 0.1f,
            // Etc...
        };
        aMash02 = new AttackClass()
        {
            hitbox = new Vector4(1.5f, 0.0f, 1.5f, 1.0f),
            moveDistance = new Vector2(0.0f, 0.0f),
            playerVel = new Vector2(0.0f, 7.5f),
            knockback = new Vector2(0.0f, 6.0f),
            moveName = "AirMash02",
            grounded = false,
            damage = 1.0f,
            startup = 0.05f,
            atkTime = 0.05f,
            recovery = 0.25f,
            walkTime = 0.3f,
            // Etc...
        };
        aMash03F = new AttackClass()
        {
            hitbox = new Vector4(1.5f, 0.0f, 1.5f, 1.0f),
            moveDistance = new Vector2(0.0f, 0.0f),
            playerVel = new Vector2(0.0f, 5.0f),
            knockback = new Vector2(10.0f, -10.0f),
            moveName = "AirMash03F",
            grounded = false,
            damage = 2.0f,
            startup = 0.1f,
            atkTime = 0.05f,
            recovery = 0.35f,
            walkTime = 0.1f,
            // Etc...
        };
        aMash01.nextNorm = aMash02;
        aMash02.nextNorm = aMash03F;

        awLauncher01 = new AttackClass()
        {
            hitbox = new Vector4(1.0f, -0.75f, 1.0f, 1.5f),
            moveDistance = new Vector2(0.0f, 0.0f),
            playerVel = new Vector2(0.0f, 10.0f),
            knockback = new Vector2(0.0f, 10.0f),
            moveName = "AirLauncher01",
            grounded = false,
            damage = 2.0f,
            startup = 0.05f,
            atkTime = 0.3f,
            recovery = 0.25f,
            walkTime = 0.1f,
            // Etc...
        };
        awLauncher02F = new AttackClass()
        {
            hitbox = new Vector4(1.5f, 0.5f, 1.5f, 2.1f),
            moveDistance = new Vector2(0.0f, 0.0f),
            playerVel = new Vector2(0.0f, -25.0f),
            knockback = new Vector2(1.0f, -10.0f),
            moveName = "Launcher02F",
            grounded = false,
            damage = 2.0f,
            startup = 0.1f,
            atkTime = 0.2f,
            recovery = 0.2f,
            walkTime = 0.1f,
            // Etc...
        };
        aMash02.nextWait = awLauncher01;
        awLauncher01.nextNorm = awLauncher02F;

        amDash = new AttackClass()
        {
            hitbox = new Vector4(0.75f, -0.1f, 1.0f, 1.75f),
            moveDistance = new Vector2(0.0f, 0.0f),
            playerVel = new Vector2(7.0f, 7.5f),
            knockback = new Vector2(-10.0f, -10.0f),
            moveName = "Lock & Key",
            grounded = false,
            damage = 1.0f,
            startup = 0.1f,
            atkTime = 0.15f,
            recovery = 0.25f,
            walkTime = 0.1f,
            // Etc...
        };
    }
}