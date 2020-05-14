using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortBtn : MonoBehaviour
{
    private Observer obs;

    public string title;
    public string summary;
    public string fullInfo;
    public Sprite gamePreview;

    public void Awake()
    {
        obs = GameObject.Find("Main Camera").GetComponent<Observer>();
        this.transform.GetChild(0).gameObject.GetComponent<Text>().text = title;
    }

    public void UpdateInfo()
    {
        obs.UpdateInfo(title, summary, fullInfo, gamePreview);
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
