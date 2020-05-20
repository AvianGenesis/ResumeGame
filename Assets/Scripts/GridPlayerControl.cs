using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerControl : MonoBehaviour
{
    private bool canMove;
    private GridSpace curGS;
    [SerializeField] private GameObject curSpace;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        transform.position = curSpace.transform.position;
        curGS = curSpace.GetComponent<GridSpace>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdatePos(GameObject nextSpace)
    {
        curSpace = nextSpace;
        transform.position = curSpace.transform.position;
        curGS = curSpace.GetComponent<GridSpace>();
    }

    void OnUp()
    {
        if(curGS.north != null)
        {
            UpdatePos(curGS.north);
        }
    }

    void OnDown()
    {
        if (curGS.south != null)
        {
            UpdatePos(curGS.south);
        }
    }

    void OnLeft()
    {
        if (curGS.west != null)
        {
            UpdatePos(curGS.west);
        }
    }

    void OnRight()
    {
        if (curGS.east != null)
        {
            UpdatePos(curGS.east);
        }
    }
}
