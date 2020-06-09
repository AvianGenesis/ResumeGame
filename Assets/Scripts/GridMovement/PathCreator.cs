using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    private RaycastHit hit;
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
        if (curGS.NPath && !curGS.nBuilt)
        {
            curGS.nBuilt = true;
            nextSpace = curGS.north;
            nextGS = nextSpace.GetComponent<GridSpace>();
            if (nextGS.SPath)
            {
                nextGS.sBuilt = true;
                BuildTwoWay(curSpace.transform.position, nextSpace.transform.position);
            }
            else
            {
                BuildOneWay(curSpace.transform.position, nextSpace.transform.position);
            }
            CheckSpace(nextSpace);
        }

        if (curGS.SPath && !curGS.sBuilt)
        {
            curGS.sBuilt = true;
            nextSpace = curGS.south;
            nextGS = nextSpace.GetComponent<GridSpace>();
            if (nextGS.NPath)
            {
                nextGS.nBuilt = true;
                BuildTwoWay(curSpace.transform.position, nextSpace.transform.position);
            }
            else
            {
                BuildOneWay(curSpace.transform.position, nextSpace.transform.position);
            }
            CheckSpace(nextSpace);
        }

        if (curGS.WPath && !curGS.wBuilt)
        {
            curGS.wBuilt = true;
            nextSpace = curGS.west;
            nextGS = nextSpace.GetComponent<GridSpace>();
            if (nextGS.EPath)
            {
                nextGS.eBuilt = true;
                BuildTwoWay(curSpace.transform.position, nextSpace.transform.position);
            }
            else
            {
                BuildOneWay(curSpace.transform.position, nextSpace.transform.position);
            }
            CheckSpace(nextSpace);
        }

        if (curGS.EPath && !curGS.eBuilt)
        {
            curGS.eBuilt = true;
            nextSpace = curGS.east;
            nextGS = nextSpace.GetComponent<GridSpace>();
            if (nextGS.WPath)
            {
                nextGS.wBuilt = true;
                BuildTwoWay(curSpace.transform.position, nextSpace.transform.position);
            }
            else
            {
                BuildOneWay(curSpace.transform.position, nextSpace.transform.position);
            }
            CheckSpace(nextSpace);
        }
    }

    /* Attempt at arbitrating above code */
    private void CheckPath(ref bool curPath, GameObject nextSpace, ref bool nextPath)
    {
        if (!curPath)
        {
            curPath = true;
            if (nextPath)
            {

            }
        }
    }

    private void BuildOneWay(Vector3 start, Vector3 end)
    {
        Vector3 mid = (end - start);
        GameObject path = Instantiate(oneWay);
        GameObject line = path.transform.GetChild(0).gameObject;
        GameObject arrow = path.transform.GetChild(1).gameObject;
        line.transform.localScale = new Vector3(line.transform.localScale.x, line.transform.localScale.y, mid.magnitude);
        arrow.transform.localPosition = new Vector3(0.0f, 0.0f, mid.magnitude / 2.0f - 2.3f);
        path.transform.position = start + (mid / 2.0f);
        path.transform.LookAt(end);
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
