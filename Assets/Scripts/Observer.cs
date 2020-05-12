using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observer : MonoBehaviour
{
    public Text summary;
    public Text fullInfo;
    public Image preview;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInfo(string summ, string fInfo, Sprite prev)
    {
        summary.text = summ;
        //fullInfo.text = fInfo;
        preview.sprite = prev;
    }
}
