using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GridObserver : MonoBehaviour
{
    private int turnMoves;
    private bool isMoving;
    private bool manual;
    private GridPlayerControl gpc;
    private GameObject prevHover;
    private GridSpace target;
    private RaycastHit hit;
    private Ray ray;
    private CursorChange cc;
    [SerializeField] private GridSpace[] gsArr;
    [SerializeField] private Button autoBtn;
    [SerializeField] private Button manBtn;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        manual = false;
        gpc = GetComponent<GridPlayerControl>();
        cc = GetComponent<CursorChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manual && gpc.moveCount == turnMoves)
        {
            autoBtn.interactable = true;
        }
        else
        {
            autoBtn.interactable = false;
        }

        /* Detect when mouse hovers over space */
        if (!manual)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100) && !isMoving)
            {
                //Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.tag.Equals("GridSpace") && prevHover != hit.transform.gameObject && hit.transform.gameObject.GetComponent<GridSpace>().MoveQueue.Count > 0)
                {
                    prevHover = hit.transform.gameObject;
                    prevHover.GetComponent<GridSpace>().ToggleHighlight();
                    cc.SetHand();
                }
                else if (prevHover != null && prevHover != hit.transform.gameObject)
                {
                    prevHover.GetComponent<GridSpace>().ToggleHighlight();
                    prevHover = null;
                    cc.SetPointer();
                }
            }
            else if (prevHover != null)
            {
                prevHover.GetComponent<GridSpace>().ToggleHighlight();
                prevHover = null;
                cc.SetPointer();
            }

            if (isMoving && !gpc.isMoving)
            {
                gpc.SetMoving(CharToSpace(target.MoveQueue.Dequeue(), gpc.curSpace.GetComponent<GridSpace>()));
                if (target.MoveQueue.Count == 0)
                {
                    isMoving = false;
                    foreach (GridSpace gs in gsArr)
                    {
                        gs.MoveQueue = new Queue<char>();
                    }
                }
            }
        }
    }

    /* Button interactions */
    public void SetMoveCount(int count)
    {
        turnMoves = count;
        gpc.moveCount = count;
        gpc.FindSpaces(gpc.curSpace, count, new Queue<char>());
        SetManual();
        autoBtn.interactable = true;
    }

    public void SetManual()
    {
        manual = true;
        gpc.SetManual();
    }

    public void SetAutomatic()
    {
        manual = false;
        gpc.SetAutomatic();
    }

    /* Input */
    void OnClick()
    {
        if(prevHover != null && prevHover.tag.Equals("GridSpace") && prevHover.GetComponent<GridSpace>().MoveQueue.Count > 0)
        {
            isMoving = true;
            gpc.moveCount = 0;
            target = prevHover.GetComponent<GridSpace>();
            manBtn.interactable = false;
            foreach (GridSpace gs in gsArr)
            {
                gs.ArrowOff();
            }
        }
    }

    /*******************/
    /* Char Conversion */
    /*******************/
    public GameObject CharToSpace(char dir, GridSpace gs)
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

    public bool CharToPath(char dir, GridSpace gs)
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

    public char OppChar(char ch)
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
}
