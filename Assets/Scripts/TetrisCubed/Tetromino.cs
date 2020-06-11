using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino
{

    public Vector3 spawn;
    public Vector3[] locs { get; set; } = new Vector3[4];
    public Color col { get; }

    public Tetromino(Vector3[] blockLocs, Color blockCol, Vector3 wellSize)
    {
        spawn = new Vector3((int)(wellSize.x / 2), wellSize.y - 6, (int)(wellSize.z / 2));
        locs = blockLocs;
        col = blockCol;
    }

    public Tetromino(Tetromino prevTetro)
    {
        locs = new Vector3[4] { prevTetro.spawn - prevTetro.locs[0],
                                prevTetro.spawn - prevTetro.locs[1],
                                prevTetro.spawn - prevTetro.locs[2],
                                prevTetro.spawn - prevTetro.locs[3] };
        col = prevTetro.col;
    }
    
    /******************/
    /* Block Movement */
    /******************/
    public void Fall()
    {
        for(int i = 0; i < locs.Length; i++)
        {
            locs[i].y -= 1;
        }
    }

    public void Rise()
    {
        for (int i = 0; i < locs.Length; i++)
        {
            locs[i].y += 1;
        }
    }

    public void MoveUp()
    {
        for (int i = 0; i < locs.Length; i++)
        {
            locs[i].z += 1;
        }
    }

    public void MoveDown()
    {
        for (int i = 0; i < locs.Length; i++)
        {
            locs[i].z -= 1;
        }
    }

    public void MoveRight()
    {
        for (int i = 0; i < locs.Length; i++)
        {
            locs[i].x += 1;
        }
    }

    public void MoveLeft()
    {
        for (int i = 0; i < locs.Length; i++)
        {
            locs[i].x -= 1;
        }
    }

    public void TiltLeft()
    {
        for (int i = 1; i < locs.Length; i++)
        {
            locs[i].Set(-(locs[i].y - locs[0].y) + locs[0].x,
                        (locs[i].x - locs[0].x) + locs[0].y,
                        locs[i].z);
        }
    }

    public void TiltRight()
    {
        for (int i = 1; i < locs.Length; i++)
        {
            locs[i].Set((locs[i].y - locs[0].y) + locs[0].x,
                        -(locs[i].x - locs[0].x) + locs[0].y,
                        locs[i].z);
        }
    }

    public void RotateUp()
    {
        for (int i = 1; i < locs.Length; i++)
        {
            locs[i].Set(locs[i].x,
                        -(locs[i].z - locs[0].z) + locs[0].y,
                        (locs[i].y - locs[0].y) + locs[0].z);
        }
    }

    public void RotateDown()
    {
        for (int i = 1; i < locs.Length; i++)
        {
            locs[i].Set(locs[i].x,
                        (locs[i].z - locs[0].z) + locs[0].y,
                        -(locs[i].y - locs[0].y) + locs[0].z);
        }
    }

    public void RotateLeft()
    {
        for (int i = 1; i < locs.Length; i++)
        {
            locs[i].Set((locs[i].z - locs[0].z) + locs[0].x,
                        locs[i].y,
                        -(locs[i].x - locs[0].x) + locs[0].z);
        }
    }

    public void RotateRight()
    {
        for (int i = 1; i < locs.Length; i++)
        {
            locs[i].Set(-(locs[i].z - locs[0].z) + locs[0].x,
                        locs[i].y,
                        (locs[i].x - locs[0].x) + locs[0].z);
        }
    }
}
