using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class WellScript : MonoBehaviour
{
    public int wellAreaDim;
    public GameObject tetroCube;
    public Transform camtrans;
    public Text scoreLabel;
    public Text levelLabel;
    public Text fastFallLabel;
    public Color Gcol;
    public Color Icol;
    public Color Jcol;
    public Color Ocol;
    public Color Qcol;
    public Color Tcol;
    public Color Vcol;
    public Color Zcol;
    public Color blankCol;
    public GameManager gamemanager;

    private int planesCleared;
    private int pClearsFrame;
    private int level;
    private int score;
    private float fallCount;
    private float fallSpeed;
    private float stopCount;
    private bool fastFall;
    private bool isFull;
    private Vector3 cubeLoc;
    private Vector3 wellVolume;
    private Vector3[] prevTetLocs;
    private Vector3[] shadowLocs;
    private GameObject[,,] well;
    private Tetromino curBlock;
    private Tetromino nextBlock;
    private Tetromino Gblock;
    private Tetromino Iblock;
    private Tetromino Jblock;
    private Tetromino Oblock;
    private Tetromino Qblock;
    private Tetromino Tblock;
    private Tetromino Vblock;
    private Tetromino Zblock;
    private Tetromino[] blockArr = new Tetromino[8];
    private Queue<int> blockQueue = new Queue<int>();



    // Start is called before the first frame update
    void Start()
    {
        planesCleared = 0;
        pClearsFrame = 0;
        level = 1;
        score = 0;
        fallCount = 0.0f;
        fallSpeed = 0.75f;
        wellVolume = new Vector3(wellAreaDim, 26, wellAreaDim);
        fastFall = false;
        isFull = true;

        well = new GameObject[(int)wellVolume.x, (int)wellVolume.y, (int)wellVolume.z];

        /* Find camera */
        camtrans = GameObject.Find("Main Camera").GetComponent<Transform>();

        /* Create Well */
        for (int x = 0; x < wellVolume.x; x++)
        {
            for (int y = 0; y < wellVolume.y; y++)
            {
                for (int z = 0; z < wellVolume.z; z++)
                {
                    well[x, y, z] = Instantiate(tetroCube);
                    well[x, y, z].transform.position = new Vector3(x, y, z);
                    well[x, y, z].SetActive(false);
                }
            }
        }

        /* Create Blocks */
        Gblock = new Tetromino(new Vector3[4] { new Vector3(0, 0, 0),
                                                new Vector3(0, 0, 1),
                                                new Vector3(0, 1, 0),
                                                new Vector3(1, 1, 0) }, Gcol, wellVolume);
        Iblock = new Tetromino(new Vector3[4] { new Vector3(0, 1, 0),
                                                new Vector3(0, 0, 0),
                                                new Vector3(0, 2, 0),
                                                new Vector3(0, 3, 0) }, Icol, wellVolume);
        Jblock = new Tetromino(new Vector3[4] { new Vector3(0, 1, 0),
                                                new Vector3(0, 0, 0),
                                                new Vector3(0, 2, 0),
                                                new Vector3(1, 2, 0) }, Jcol, wellVolume);
        Oblock = new Tetromino(new Vector3[4] { new Vector3(0, 0, 0),
                                                new Vector3(1, 0, 0),
                                                new Vector3(0, 1, 0),
                                                new Vector3(1, 1, 0) }, Ocol, wellVolume);
        Qblock = new Tetromino(new Vector3[4] { new Vector3(0, 0, 1),
                                                new Vector3(0, 0, 0),
                                                new Vector3(0, 1, 1),
                                                new Vector3(1, 1, 1) }, Qcol, wellVolume);
        Tblock = new Tetromino(new Vector3[4] { new Vector3(1, 1, 0),
                                                new Vector3(1, 0, 0),
                                                new Vector3(2, 1, 0),
                                                new Vector3(0, 1, 0) }, Tcol, wellVolume);
        Vblock = new Tetromino(new Vector3[4] { new Vector3(0, 1, 0),
                                                new Vector3(0, 0, 0),
                                                new Vector3(1, 1, 0),
                                                new Vector3(0, 1, 1) }, Vcol, wellVolume);
        Zblock = new Tetromino(new Vector3[4] { new Vector3(1, 0, 0),
                                                new Vector3(0, 0, 0),
                                                new Vector3(1, 1, 0),
                                                new Vector3(2, 1, 0) }, Zcol, wellVolume);
        blockArr[0] = Gblock;
        blockArr[1] = Iblock;
        blockArr[2] = Jblock;
        blockArr[3] = Oblock;
        blockArr[4] = Qblock;
        blockArr[5] = Tblock;
        blockArr[6] = Vblock;
        blockArr[7] = Zblock;

        NewQueue();
        NewBlock();
        NewBlock();
        DrawBlocks();

        
        gamemanager = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
    }

    // Update is called once per frame
    void Update()
    {
        fallCount += Time.deltaTime;
        if (fallCount >= fallSpeed - 0.07f * level)
        {
            // Spawn new block
            if (CanMove("fall"))
            {
                HideBlocks();
                curBlock.Fall();
            }
            else
            {
                for (int y = 0; y < wellVolume.y; y++)
                {
                    for (int x = 0; x < wellVolume.x; x++)
                    {
                        for (int z = 0; z < wellVolume.z; z++)
                        {
                            if(!well[x, y, z].activeSelf)
                            {
                                isFull = false;
                            }
                        }
                    }
                    if (isFull)
                    {
                        HidePlane(y);
                        y--;


                        pClearsFrame++;

                        planesCleared++;
                        if(planesCleared % 10 == 0)
                        {
                            level++;
                            levelLabel.text = "Level: " + level;
                        }
                    }
                    isFull = true;
                }

                if(pClearsFrame > 0)
                {
                    Debug.Log("pClearsFrame: " + pClearsFrame);
                    switch(pClearsFrame)
                    { 
                        case 1:
                            score += 40 * level;
                            break;
                        case 2:
                            score += 100 * level;
                            break;
                        case 3:
                            score += 300 * level;
                            break;
                        case 4:
                            score += 1200 * level;
                            break;
                        default:
                            break;
                    }
                    scoreLabel.text = "Score: " + score;
                    pClearsFrame = 0;
                }

                foreach (Vector3 loc in curBlock.locs) //See if stopped block is above threshold
                {
                    if(loc.y >= 21)
                    {
                        SceneManager.LoadScene("endScene");
                    }
                }
                NewBlock();
                if (!CanMove("fall"))
                {
                    curBlock.Rise();
                    curBlock.Rise();
                    curBlock.Rise();
                    curBlock.Rise();
                }
            }

            DrawBlocks();

            fallCount = 0.0f;

        }

    }

    /****************/
    /* Player Input */
    /****************/
    void OnMoveUp()
    {
        DynamicMove(DiscreteCamDir2D('f'));
    }

    void OnMoveDown()
    {
        DynamicMove(-DiscreteCamDir2D('f'));
    }

    void OnMoveLeft()
    {
        DynamicMove(-DiscreteCamDir2D('r'));
    }

    void OnMoveRight()
    {
        DynamicMove(DiscreteCamDir2D('r'));
    }

    void DynamicMove(Vector3 v) {
        if (v.x != 0) {
            if (v.x > 0) {Move("mr");} //Move in positive x direction
            else {Move("ml");} //Move in negative x direction
        }
        else if (v.z != 0) {
            if (v.z > 0) {Move("mu");} //Move in positive z direction
            else {Move("md");} //Move in negative z direction
        }
    }

    void OnTiltLeft()//Rotate about forward
    {
        DynamicRotate(DiscreteCamDir('f'));
    }

    void OnTiltRight()//Rotate about forward
    {
        DynamicRotate(-DiscreteCamDir('f'));
    }

    void OnRotateUp()//Rotate about right
    {
        DynamicRotate(DiscreteCamDir('r'));
    }

    void OnRotateDown()//Rotate about right
    {
        DynamicRotate(-DiscreteCamDir('r'));
    }

    void OnRotateLeft()//Rotate about up
    {
        DynamicRotate(DiscreteCamDir('u'));
    }

    void OnRotateRight()//Rotate about up
    {
        DynamicRotate(-DiscreteCamDir('u'));
    }

    void DynamicRotate(Vector3 v) {
        if(v.y == 0 && v.z == 0) {
            if(v.x > 0) {Move("ru");}
            else {Move("rd");}
        }
        else if(v.x == 0 && v.z == 0) {
            if(v.y > 0) {Move("rl");}
            else {Move("rr");}
        }
        else if(v.x == 0 && v.y == 0) {
            if(v.z > 0) {Move("tl");}
            else {Move("tr");}
        }
    }

    void OnFastFall() //If South button is held, block falls faster
    {
        fastFall = !fastFall;
        if (fastFall)
        {
            fallSpeed = 0.1f;
            fastFallLabel.fontStyle = FontStyle.Bold;
        }
        else
        {
            fallSpeed = 0.75f;
            fastFallLabel.fontStyle = FontStyle.Normal;
        }
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /********************/
    /* Helper Functions */
    /********************/

    /* Draw Current Block */
    private void DrawBlocks()
    {
        bool canFall = true;
        Vector3[] temp;
        shadowLocs = new Vector3[4] { curBlock.locs[0], curBlock.locs[1], curBlock.locs[2], curBlock.locs[3] };

        while (canFall)
        {
            if (CanMove("fall"))
            {
                StrToFunc("fall");
            }
            else
            {
                canFall = false;
            }
        }

        temp = new Vector3[4] { curBlock.locs[0], curBlock.locs[1], curBlock.locs[2], curBlock.locs[3] };
        curBlock.locs = new Vector3[4] { shadowLocs[0], shadowLocs[1], shadowLocs[2], shadowLocs[3] };
        shadowLocs = new Vector3[4] { temp[0], temp[1], temp[2], temp[3] };

        foreach (Vector3 loc in shadowLocs)
        {
            well[(int)loc.x, (int)loc.y, (int)loc.z].GetComponent<Renderer>().material.color = blankCol;
            well[(int)loc.x, (int)loc.y, (int)loc.z].GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            well[(int)loc.x, (int)loc.y, (int)loc.z].SetActive(true);
        }

        foreach (Vector3 loc in curBlock.locs)
        {
            well[(int)loc.x, (int)loc.y, (int)loc.z].GetComponent<Renderer>().material.color = curBlock.col;
            well[(int)loc.x, (int)loc.y, (int)loc.z].SetActive(true);
        }
    }

    private void HideBlocks()
    {
        foreach (Vector3 loc in shadowLocs)
        {
            well[(int)loc.x, (int)loc.y, (int)loc.z].SetActive(false);
        }

        foreach (Vector3 loc in curBlock.locs)
        {
            well[(int)loc.x, (int)loc.y, (int)loc.z].SetActive(false);
        }
    }

    /* Hides a plane and moves above blocks down */
    private void HidePlane(int plane)
    {
        for(int x = 0; x < wellVolume.x; x++)
        {
            for (int z = 0; z < wellVolume.z; z++)
            {
                well[x, plane, z].SetActive(false);
            }
        }
        
        for (int y = plane; y < wellVolume.y - 1; y++)
        {
            for (int x = 0; x < wellVolume.x; x++)
            {
                for (int z = 0; z < wellVolume.z; z++)
                {
                    if (well[x, y + 1, z].activeSelf)
                    {
                        well[x, y, z].GetComponent<Renderer>().material.color = well[x, y + 1, z].GetComponent<Renderer>().material.color;
                        well[x, y, z].SetActive(true);
                        well[x, y + 1, z].SetActive(false);
                    }
                }
            }
        }
    }

    /* Move blocks up then add a junk plane */
    private void AddJunk()
    {
        int xSpot = (int)UnityEngine.Random.Range(0, wellVolume.x - 1);
        int zSpot = (int)UnityEngine.Random.Range(0, wellVolume.z - 1);

        for (int y = (int)wellVolume.y; y > 0; y--) // Moves all blocks up
        {
            for (int x = (int)wellVolume.x - 1; x >= 0; x--)
            {
                for (int z = (int)wellVolume.z - 1; z >= 0; z--)
                {
                    if (well[x, y - 1, z].activeSelf)
                    {
                        well[x, y, z].GetComponent<Renderer>().material.color = well[x, y - 1, z].GetComponent<Renderer>().material.color;
                        well[x, y, z].SetActive(true);
                        well[x, y - 1, z].SetActive(false);
                    }
                }
            }
        }

        for (int x = (int)wellVolume.x - 1; x >= 0; x--) // Add junk line with one missing space
        {
            for (int z = (int)wellVolume.z - 1; z >= 0; z--)
            {
                if (x != xSpot || z != zSpot)
                {
                    well[x, 0, z].GetComponent<Renderer>().material.color = blankCol;
                    well[x, 0, z].SetActive(true);
                }
            }
        }
    }

    /* Fill block queue */
    private void NewQueue()
    {
        int toAdd;
        while(blockQueue.Count < 8)
        {
            toAdd = UnityEngine.Random.Range(0, 8);
            if (!blockQueue.Contains(toAdd))
            {
                blockQueue.Enqueue(toAdd);
            }
        }
    }

    private void NewBlock()
    {
        curBlock = nextBlock;
        nextBlock = new Tetromino(blockArr[blockQueue.Dequeue()]);
        if(blockQueue.Count == 0)
        {
            NewQueue();
        }
    }

    /* Arbitrated Function Converts Input to Block Move */
    void Move(String theMove)
    {
        if (CanMove(theMove))
        {
            HideBlocks();
            StrToFunc(theMove);
            DrawBlocks();
        }
    }

    /* Check for collission and return if move is valid */
    private bool CanMove(String move)
    {
        bool ret = true;

        String oppMove = GetOppMove(move);
        prevTetLocs = new Vector3[4] { curBlock.locs[0], curBlock.locs[1], curBlock.locs[2], curBlock.locs[3] };
        StrToFunc(move);

        foreach (Vector3 loc in curBlock.locs)
        {
            if (loc.x >= wellVolume.x || loc.x <= -1 || loc.y <= -1 || loc.y >= wellVolume.y || loc.z >= wellVolume.z || loc.z <= -1)
            {
                ret = false;
            }
            else if (!Array.Exists(prevTetLocs, prevLoc => prevLoc == loc) && !Array.Exists(shadowLocs, shadowLoc => shadowLoc == loc)) //Check if intersecting active blocks are from previous location or drop shadow
            {
                if (well[(int)loc.x, (int)loc.y, (int)loc.z].activeSelf)
                {
                    ret = false;
                }
            }
        }
        StrToFunc(oppMove);

        return ret;
    }

    /* Convert String to Move Function */
    private void StrToFunc(String input)
    {
        switch (input.ToLower())
        {
            case "fall":
                curBlock.Fall();
                break;
            case "rise":
                curBlock.Rise();
                break;
            case "mu":
                curBlock.MoveUp();
                break;
            case "md":
                curBlock.MoveDown();
                break;
            case "ml":
                curBlock.MoveLeft();
                break;
            case "mr":
                curBlock.MoveRight();
                break;
            case "tl":
                curBlock.TiltLeft();
                break;
            case "tr":
                curBlock.TiltRight();
                break;
            case "ru":
                curBlock.RotateUp();
                break;
            case "rd":
                curBlock.RotateDown();
                break;
            case "rl":
                curBlock.RotateLeft();
                break;
            case "rr":
                curBlock.RotateRight();
                break;
            default:
                break;
        }
    }

    private String GetOppMove(String move)
    {
        switch (move)
        {
            case "fall":
                return "rise";
            case "rise":
                return "fall";
            case "mu":
                return "md";
            case "md":
                return "mu";
            case "ml":
                return "mr";
            case "mr":
                return "ml";
            case "tl":
                return "tr";
            case "tr":
                return "tl";
            case "ru":
                return "rd";
            case "rd":
                return "ru";
            case "rl":
                return "rr";
            case "rr":
                return "rl";
            default:
                return ""; ;
        }
    }

    /* Returns unit vector of the closest cardinal direction of camera's f or r vector in 2D */
    private Vector3 DiscreteCamDir2D(char dir) {
        Vector3 v;
        if (dir == 'f') {v = camtrans.forward;}
        else {return DiscreteCamDir('r');}
        if (Mathf.Abs(v.x) > Mathf.Abs(v.z)) {
            if (v.x > 0) {return new Vector3(1,0,0);}
            else return new Vector3(-1,0,0);
        }
        else {
            if (v.z > 0) {return new Vector3(0,0,1);}
            else return new Vector3(0,0,-1);
        }
    }

    /* Returns unit vector of the closert cardinal direction of camera's f, r, or u vector in 3D */
    private Vector3 DiscreteCamDir(char dir) {
        Vector3 v;
        if (dir == 'f') {v = camtrans.forward;}
        else if (dir == 'r') {v = camtrans.right;}
        else {v = camtrans.up;}
        if (Mathf.Abs(v.x) > Mathf.Abs(v.y) && Mathf.Abs(v.x) > Mathf.Abs(v.z)) {
            if (v.x > 0) {return new Vector3(1,0,0);}
            else return new Vector3(-1,0,0);
        }
        else if (Mathf.Abs(v.z) > Mathf.Abs(v.x) && Mathf.Abs(v.z) > Mathf.Abs(v.y)) {
            if (v.z > 0) {return new Vector3(0,0,1);}
            else return new Vector3(0,0,-1);
        }
        else {
            if (v.y > 0) {return new Vector3(0,1,0);}
            else return new Vector3(0,-1,0);
        }
    }

    /* Debug */
    void PrintCoords()
    {
        foreach (Vector3 loc in curBlock.locs)
        {
            Debug.Log(loc.x + " " + loc.y + " " + loc.z);
        }
    }
}

/* https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-create-a-new-method-for-an-enumeration */
