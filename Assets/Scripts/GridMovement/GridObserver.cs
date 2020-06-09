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
    private bool promptUp;
    private bool dragging;
    private Vector2 prevPos;
    private Vector2 pos;
    private GridPlayerControl gpc;
    private GameObject prevHover;
    private GameObject start;
    private GridSpace target;
    private GridSpace[] gsArr;
    private RaycastHit hit;
    private Ray ray;
    private CursorChange cc;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject ays;
    [SerializeField] private GameObject map;
    [SerializeField] private Button autoBtn;
    [SerializeField] private Button manBtn;
    [SerializeField] private Button resBtn;
    [SerializeField] private Button spinBtn;

    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        prevPos = Input.mousePosition;
        pos = Input.mousePosition;
        isMoving = false;
        manual = false;
        promptUp = false;
        gpc = GetComponent<GridPlayerControl>();
        cc = GetComponent<CursorChange>();
        gsArr = new GridSpace[map.transform.childCount];
        for (int i = 0; i < map.transform.childCount; i++)
        {
            gsArr[i] = map.transform.GetChild(i).gameObject.GetComponent<GridSpace>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(manual)
        {
            if (gpc.moveCount == turnMoves)
            {
                autoBtn.interactable = true;
                resBtn.interactable = false;
            }
            else
            {
                autoBtn.interactable = false;
                resBtn.interactable = true;
            }
        }
        else
        {
            autoBtn.interactable = false;
        }

        if(gpc.moveCount == 0 && !gpc.isMoving)
        {
            spinBtn.interactable = true;
        }
        else
        {
            spinBtn.interactable = false;
        }

        /* Detect when mouse hovers over space */
        if (!manual && !promptUp)
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

        if (dragging && !isMoving)
        {
            pos = Input.mousePosition;
            Debug.Log(cam.transform.position);
            cam.transform.Translate((prevPos.x - pos.x) * 0.1f, 0.0f, (prevPos.y - pos.y) * 0.1f, Space.World);
            prevPos = Input.mousePosition;
        }
    }

    public void NewTurn()
    {
        gpc.spaceStack = new Stack<char>();
        start = gpc.curSpace;
        foreach (GridSpace gs in gsArr)
        {
            gs.MoveQueue = new Queue<char>();
            gs.ArrowOff();
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

    public void ResetPos()
    {
        gpc.spaceStack = new Stack<char>();
        gpc.curSpace = start;
        gpc.moveCount = turnMoves;
        gpc.transform.position = new Vector3(start.transform.position.x, start.transform.position.y + 1.1f, start.transform.position.z);
        ResetCam();
    }

    public void SetManual()
    {
        manual = true;
        gpc.SetManual();
    }

    public void SetAutomatic()
    {
        manual = false;
        resBtn.interactable = false;
        gpc.SetAutomatic();
    }

    public void TriggerYes()
    {
        gpc.spaceStack = new Stack<char>();
        isMoving = true;
        gpc.moveCount = 0;
        ays.SetActive(false);
        promptUp = false;
        ResetCam();
        foreach (GridSpace gs in gsArr)
        {
            gs.ArrowOff();
        }
    }

    public void TriggerNo()
    {
        target = null;
        manBtn.interactable = true;
        ays.SetActive(false);
        promptUp = false;
    }

    public void ResetCam()
    {
        cam.transform.localPosition = new Vector3(0.0f, 20.0f, -20.0f);
    }

    /* Input */
    void OnClick()
    {
        if(prevHover != null && prevHover.tag.Equals("GridSpace") && prevHover.GetComponent<GridSpace>().MoveQueue.Count > 0 && !promptUp)
        {
            target = prevHover.GetComponent<GridSpace>();
            manBtn.interactable = false;
            ays.SetActive(true);
            promptUp = true;
        }
    }

    void OnDrag()
    {
        if (!dragging)
        {
            prevPos = Input.mousePosition;
        }
        dragging = !dragging;
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
