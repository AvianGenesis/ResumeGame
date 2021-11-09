using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UShotUI : MonoBehaviour
{
    private Image bar;
    private Image lvl1;
    private Image lvl2;
    [SerializeField] private GameObject barObj;
    [SerializeField] private GameObject lvl1Obj;
    [SerializeField] private GameObject lvl2Obj;
    [SerializeField] private Color green;
    [SerializeField] private Color yellow;

    // Start is called before the first frame update
    void Awake()
    {
        bar = barObj.GetComponent<Image>();
        lvl1 = lvl1Obj.GetComponent<Image>();
        lvl2 = lvl2Obj.GetComponent<Image>();
    }

    public void UpdateBar(float prog)
    {
        Debug.Log("Start UpdateBar()");
        bar.color = new Color(green.r, green.g, green.b, prog);
        Debug.Log("End UpdateBar()");
    }

    public void SetLevel(int lvl)
    {
        Debug.Log("Start SetLevel()");
        switch (lvl)
        {
            case (0):
                this.gameObject.GetComponent<Image>().color = green;
                bar.color = new Color(green.r, green.g, green.b, 0);
                lvl1.color = new Color(green.r, green.g, green.b, 0);
                lvl2.color = new Color(green.r, green.g, green.b, 0);
                break;
            case (1):
                lvl1.color = new Color(green.r, green.g, green.b, 1);
                break;
            case (2):
                lvl2.color = new Color(green.r, green.g, green.b, 1);
                break;
            case (3):
                this.gameObject.GetComponent<Image>().color = yellow;
                bar.color = yellow;
                lvl1.color = yellow;
                lvl2.color = yellow;
                break;
            default:
                break;
        }
        Debug.Log("End SetLevel()");
    }
}
