using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerControl : MonoBehaviour
{
    public int moveCount;

    private float step;
    private bool canMove;
    private bool isMoving;
    private char[] directions;
    private Vector3 start;
    private Vector3 end;
    private GameObject nextSpace;
    private Stack<char> spaceStack;
    private Rigidbody rb;
    private Transform body;
    private RaycastHit hit;
    private GridSpace curGS;
    [SerializeField] private GameObject curSpace;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        isMoving = false;
        directions = new char[] { 'n', 's', 'w', 'e' };
        spaceStack = new Stack<char>();
        rb = GetComponent<Rigidbody>();
        body = transform.GetChild(0);
        transform.position = curSpace.transform.position + new Vector3(0.0f, 1.1f, 0.0f);
        curGS = curSpace.GetComponent<GridSpace>();
        FindSpaces(curSpace, moveCount, new Queue<char>());
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            step += Time.deltaTime * 20.0f;
            transform.position = Vector3.MoveTowards(new Vector3(start.x, transform.position.y, start.z), new Vector3(end.x, transform.position.y, end.z), step);
            //Debug.Log("Pos: " + transform.position);
            //Debug.Log("End: " + end);
            if (Mathf.Abs(transform.position.x - end.x) <= 0.01f && Mathf.Abs(transform.position.z - end.z) <= 0.01f)
            {
                isMoving = false;
                step = 0.0f;
                transform.position = end;
                body.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
                curSpace = nextSpace;
                curGS = curSpace.GetComponent<GridSpace>();
            }
        }
    }

    /* Keep player grounded */
    private void Update()
    {
        if (Physics.Raycast(new Ray(transform.position, Vector3.down), out hit))
        {
            transform.Translate(new Vector3(0.0f, -hit.distance + 1.1f, 0.0f));
        }
    }

    /* Trigger movement */
    private void SetMoving(GameObject next)
    {
        isMoving = true;
        nextSpace = next;
        start = curSpace.transform.position + new Vector3(0.0f, 1.1f, 0.0f);
        end = nextSpace.transform.position + new Vector3(0.0f, 1.1f, 0.0f);
        body.LookAt(end);
    }

    /* Monitor move count and direction */
    private void CheckCount(char next)
    {
        if (!isMoving && CharToSpace(next, curSpace.GetComponent<GridSpace>()) != null)
        {
            Debug.Log("Should move");
            if (spaceStack.Count > 0)
            {
                Debug.Log("next: " + next + "\nPeek: " + spaceStack.Peek());
                if (next == OppChar(spaceStack.Peek()))
                {
                    moveCount++;
                    spaceStack.Pop();
                    SetMoving(CharToSpace(next, curSpace.GetComponent<GridSpace>()));
                    return;
                }
            }
            if (moveCount > 0 && CharToPath(next, curSpace.GetComponent<GridSpace>()))
            {
                moveCount--;
                spaceStack.Push(next);
                SetMoving(CharToSpace(next, curSpace.GetComponent<GridSpace>()));
            }
        }
    }

    /* Find spaces player can move to */
    private void FindSpaces(GameObject space, int movesLeft, Queue<char> toPass, char prev = 'x')
    {
        GameObject nxt;
        Queue<char> dirQueue = new Queue<char>(toPass);
        if(prev != 'x')
        {
            dirQueue.Enqueue(prev);
        }
        if(movesLeft == 0)
        {
            space.GetComponent<GridSpace>().ArrowOn();
            space.GetComponent<GridSpace>().MoveQueue = dirQueue;
        }
        else
        {
            foreach (char dir in directions)
            {
                nxt = CharToSpace(dir, space.GetComponent<GridSpace>());
                if (dirQueue.Count > 0)
                {
                    if(OppChar(prev) != dir && CharToPath(dir, space.GetComponent<GridSpace>()))
                    {
                        FindSpaces(nxt, movesLeft - 1, dirQueue, dir);
                    }
                }
                else if (CharToPath(dir, space.GetComponent<GridSpace>()))
                {
                    FindSpaces(nxt, movesLeft - 1, dirQueue, dir);
                }
            }
        }
    }

    private GameObject CharToSpace(char dir, GridSpace gs)
    {
        switch (dir)
        {
            case ('n'):
                return gs.north;
            case ('s'):
                return gs.south;
            case ('w'):
                return gs.west;
            case ('e'):
                return gs.east;
            default:
                Debug.LogError("CharToSpace incorrect input");
                return null;
        }
    }

    private bool CharToPath(char dir, GridSpace gs)
    {
        switch (dir)
        {
            case ('n'):
                return gs.NPath;
            case ('s'):
                return gs.SPath;
            case ('w'):
                return gs.WPath;
            case ('e'):
                return gs.EPath;
            default:
                Debug.LogError("CharToSpace incorrect input");
                return false;
        }
    }

    private char OppChar(char ch)
    {
        switch (ch)
        {
            case ('n'):
                return 's';
            case ('s'):
                return 'n';
            case ('w'):
                return 'e';
            case ('e'):
                return 'w';
            default:
                Debug.LogError("OppChar incorrect input");
                return 'x';
        }
    }


    /*********/
    /* Input */
    /*********/
    void OnUp()
    {
        CheckCount('n');
    }

    void OnDown()
    {
        CheckCount('s');
    }

    void OnLeft()
    {
        CheckCount('w');
    }

    void OnRight()
    {
        CheckCount('e');
    }
}
