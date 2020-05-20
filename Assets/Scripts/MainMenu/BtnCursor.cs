using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCursor : MonoBehaviour
{
    private Observer obs;

    // Start is called before the first frame update
    void Start()
    {
        obs = GameObject.Find("Main Camera").GetComponent<Observer>();
    }

    public void SetPointer()
    {
        obs.SetPointer();
    }

    public void SetHand()
    {
        obs.SetHand();
    }
}
