using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject highlight;

    public bool nBuilt;
    public bool sBuilt;
    public bool wBuilt;
    public bool eBuilt;
    public bool NPath;
    public bool SPath;
    public bool WPath;
    public bool EPath;
    public Queue<char> MoveQueue { get; set; }
    public GameObject north;
    public GameObject south;
    public GameObject west;
    public GameObject east;

    // Start is called before the first frame update
    void Awake()
    {
        //arrow = this.transform.GetChild(0).gameObject;
        MoveQueue = new Queue<char>();
    }

    private bool SetPathBool(GameObject direction)
    {
        if(direction == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ArrowOn()
    {
        arrow.SetActive(true);
    }

    public void ArrowOff()
    {
        arrow.SetActive(false);
    }

    public void ToggleHighlight()
    {
        highlight.SetActive(!highlight.activeSelf);
    }
}
