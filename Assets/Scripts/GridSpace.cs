using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    private GameObject arrow;

    public Queue<char> MoveQueue { get; set; }
    public GameObject north;
    public GameObject south;
    public GameObject west;
    public GameObject east;

    // Start is called before the first frame update
    void Start()
    {
        arrow = this.transform.GetChild(0).gameObject;
        MoveQueue = new Queue<char>();
    }

    public void ToggleArrow()
    {
        arrow.SetActive(!arrow.activeSelf);
    }
}
