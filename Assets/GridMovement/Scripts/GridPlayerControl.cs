using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridPlayerControl : MonoBehaviour
{
    public int moveCount;
    public bool isMoving;
    public GameObject curSpace;
    public Stack<char> spaceStack;

    private float step;
    private bool canMove;
    private bool manual;
    private char[] directions;
    private Vector3 start;
    private Vector3 end;
    private GridObserver go;
    private GameObject nextSpace;
    private Transform body;
    private RaycastHit hit;
    private GridSpace curGS;
    [SerializeField] private Text moves;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        canMove = true;
        manual = false;
        directions = new char[] { 'n', 's', 'w', 'e' };
        go = GetComponent<GridObserver>();
        spaceStack = new Stack<char>();
        body = transform.GetChild(0);
        transform.position = curSpace.transform.position + new Vector3(0.0f, 1.1f, 0.0f);
        curGS = curSpace.GetComponent<GridSpace>();
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

        moves.text = moveCount.ToString();
    }

    /* Trigger movement */
    public void SetMoving(GameObject next)
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
        if (!isMoving && go.CharToSpace(next, curSpace.GetComponent<GridSpace>()) != null && manual)
        {
            go.ResetCam();
            if (spaceStack.Count > 0)
            {
                //Debug.Log("next: " + next + "\nPeek: " + spaceStack.Peek());
                if (next == go.OppChar(spaceStack.Peek()))
                {
                    moveCount++;
                    spaceStack.Pop();
                    SetMoving(go.CharToSpace(next, curSpace.GetComponent<GridSpace>()));
                    return;
                }
            }
            if (moveCount > 0 && go.CharToPath(next, curSpace.GetComponent<GridSpace>()))
            {
                moveCount--;
                spaceStack.Push(next);
                SetMoving(go.CharToSpace(next, curSpace.GetComponent<GridSpace>()));
            }
        }
    }

    /* Find spaces player can move to */
    public void FindSpaces(GameObject space, int movesLeft, Queue<char> toPass, char prev = 'x')
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
                nxt = go.CharToSpace(dir, space.GetComponent<GridSpace>());
                if (dirQueue.Count > 0)
                {
                    if(go.OppChar(prev) != dir && go.CharToPath(dir, space.GetComponent<GridSpace>()))
                    {
                        FindSpaces(nxt, movesLeft - 1, dirQueue, dir);
                    }
                }
                else if (go.CharToPath(dir, space.GetComponent<GridSpace>()))
                {
                    FindSpaces(nxt, movesLeft - 1, dirQueue, dir);
                }
            }
        }
    }

    public void SetManual()
    {
        manual = true;
    }

    public void SetAutomatic()
    {
        manual = false;
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
