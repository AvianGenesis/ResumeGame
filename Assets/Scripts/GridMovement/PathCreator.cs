using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    private GridSpace startGS;
    [SerializeField] private GameObject startSpace;
    [SerializeField] private GameObject oneWay;
    [SerializeField] private GameObject twoWay;

    // Start is called before the first frame update
    void Start()
    {
        startGS = startSpace.GetComponent<GridSpace>();
        CheckSpace(startSpace);
    }

    private void CheckSpace(GameObject curSpace)
    {
        GridSpace curGS = curSpace.GetComponent<GridSpace>();
        GameObject nextSpace;
        GridSpace nextGS;
        if (!curGS.NPath)
        {
            curGS.NPath = true;
            nextSpace = curGS.north;
            nextGS = nextSpace.GetComponent<GridSpace>();
            if (nextGS.SPath)
            {
                //build one-way
            }
            else
            {
                nextGS.SPath = true;
                BuildTwoWay(curSpace.transform.position, nextSpace.transform.position);
            }
            CheckSpace(nextSpace);
        }

        if (!curGS.SPath)
        {
            curGS.SPath = true;
            nextSpace = curGS.south;
            nextGS = nextSpace.GetComponent<GridSpace>();
            if (nextGS.NPath)
            {
                //build one-way
            }
            else
            {
                nextGS.NPath = true;
                BuildTwoWay(curSpace.transform.position, nextSpace.transform.position);
            }
            CheckSpace(nextSpace);
        }

        if (!curGS.WPath)
        {
            curGS.WPath = true;
            nextSpace = curGS.west;
            nextGS = nextSpace.GetComponent<GridSpace>();
            if (nextGS.EPath)
            {
                //build one-way
            }
            else
            {
                nextGS.EPath = true;
                BuildTwoWay(curSpace.transform.position, nextSpace.transform.position);
            }
            CheckSpace(nextSpace);
        }

        if (!curGS.EPath)
        {
            curGS.EPath = true;
            nextSpace = curGS.east;
            nextGS = nextSpace.GetComponent<GridSpace>();
            if (nextGS.WPath)
            {
                //build one-way
            }
            else
            {
                nextGS.WPath = true;
                BuildTwoWay(curSpace.transform.position, nextSpace.transform.position);
            }
            CheckSpace(nextSpace);
        }
    }

    private void BuildTwoWay(Vector3 start, Vector3 end)
    {
        Vector3 mid = (end - start);
        GameObject path = Instantiate(twoWay);
        path.transform.localScale = new Vector3(path.transform.localScale.x, path.transform.localScale.y, mid.magnitude);
        path.transform.position = start + (mid / 2.0f);
        path.transform.LookAt(end);
    }
}
