using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortBtn : MonoBehaviour
{
    private Observer obs;

    public string sceneName;
    public string title;
    public string summary;
    public string addInfo;
    public Sprite gamePreview;

    public void Awake()
    {
        obs = GameObject.Find("Main Camera").GetComponent<Observer>();
        this.transform.GetChild(0).gameObject.GetComponent<Text>().text = title;
    }

    public void UpdateInfo()
    {
        obs.UpdateInfo(sceneName, title, summary, addInfo, gamePreview);
    }
}
