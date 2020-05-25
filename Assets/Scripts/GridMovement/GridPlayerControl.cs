using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerControl : MonoBehaviour
{
    public int moveCount;

    private float step;
    private bool canMove;
    private bool isMoving;
    private Vector3 start;
    private Vector3 end;
    private GameObject nextSpace;
    private Stack<GameObject> spaceStack;
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
        spaceStack = new Stack<GameObject>();
        rb = GetComponent<Rigidbody>();
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
    private void CheckCount(GameObject next)
    {
        if (!isMoving && next != null)
        {
            if (spaceStack.Count > 0)
            {
                if (next == spaceStack.Peek())
                {
                    moveCount++;
                    spaceStack.Pop();
                    SetMoving(next);
                    return;
                }
            }
            if (moveCount > 0)
            {
                moveCount--;
                spaceStack.Push(curSpace);
                SetMoving(next);
            }
        }
    }


    /*********/
    /* Input */
    /*********/
    void OnUp()
    {
        CheckCount(curGS.north);
    }

    void OnDown()
    {
        CheckCount(curGS.south);
    }

    void OnLeft()
    {
        CheckCount(curGS.west);
    }

    void OnRight()
    {
        CheckCount(curGS.east);
    }
}
