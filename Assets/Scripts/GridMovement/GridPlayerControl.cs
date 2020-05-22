using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerControl : MonoBehaviour
{
    private float step;
    private bool canMove;
    private bool isMoving;
    private Vector3 start;
    private Vector3 end;
    private GameObject nextSpace;
    private Transform body;
    private GridSpace curGS;
    [SerializeField] private GameObject curSpace;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        isMoving = false;
        body = transform.GetChild(0);
        transform.position = curSpace.transform.position + new Vector3(0.0f, 1.1f, 0.0f);
        curGS = curSpace.GetComponent<GridSpace>();
    }

    private void Update()
    {
        if (isMoving)
        {
            step += Time.deltaTime * 20.0f;
            transform.position = Vector3.MoveTowards(start, end, step);
            if(Vector3.Distance(transform.position, end) <= 0.01f)
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

    private void SetMoving()
    {
        isMoving = true;
        start = curSpace.transform.position + new Vector3(0.0f, 1.1f, 0.0f);
        end = nextSpace.transform.position + new Vector3(0.0f, 1.1f, 0.0f);
        body.LookAt(end);
    }

    void OnUp()
    {
        if(curGS.north != null && !isMoving)
        {
            nextSpace = curGS.north;
            SetMoving();
        }
    }

    void OnDown()
    {
        if (curGS.south != null && !isMoving)
        {
            nextSpace = curGS.south;
            SetMoving();
        }
    }

    void OnLeft()
    {
        if (curGS.west != null && !isMoving)
        {
            nextSpace = curGS.west;
            SetMoving();
        }
    }

    void OnRight()
    {
        if (curGS.east != null && !isMoving)
        {
            nextSpace = curGS.east;
            SetMoving();
        }
    }
}
