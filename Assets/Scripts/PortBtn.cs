using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortBtn : MonoBehaviour
{
    private Observer obs;

    public string summary;
    public string fullInfo;
    public Sprite gamePreview;

    public void Start()
    {
        obs = GameObject.Find("Main Camera").GetComponent<Observer>();
    }

    public void UpdateInfo()
    {
        obs.UpdateInfo(summary, fullInfo, gamePreview);
    }
}
