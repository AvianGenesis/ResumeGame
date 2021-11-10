using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    [NonSerialized] public bool nBuilt;
    [NonSerialized] public bool sBuilt;
    [NonSerialized] public bool wBuilt;
    [NonSerialized] public bool eBuilt;
    public bool NPath;
    public bool SPath;
    public bool WPath;
    public bool EPath;
    public Queue<char> MoveQueue { get; set; }
    public GameObject north;
    public GameObject south;
    public GameObject west;
    public GameObject east;

    private RaycastHit hit;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject highlight;

    // Start is called before the first frame update
    void Awake()
    {
        MoveQueue = new Queue<char>();
        if (Physics.Raycast(new Ray(transform.position, Vector3.down), out hit))
        {
            transform.Translate(new Vector3(0.0f, -hit.distance + 0.5f, 0.0f));
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            Debug.Log(hit.normal);
        }
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
