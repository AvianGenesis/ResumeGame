using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridBtn : MonoBehaviour
{
    public GameObject hintText;
    public Button automatic;
    public Button manual;

    private CursorChange cc;
    private GridObserver obs;
    private Button btn;

    private void Start()
    {
        cc = GetComponent<CursorChange>();
        obs = GameObject.Find("Player").GetComponent<GridObserver>();
        btn = GetComponent<Button>();
    }

    public void Spin()
    {
        obs.NewTurn();
        int rand = Random.Range(1, 7);
        Debug.Log(rand);
        obs.SetMoveCount(rand);
        btn.interactable = false;
    }

    public void ResetPos()
    {
        obs.ResetPos();
    }

    public void SetManual()
    {
        obs.SetManual();
        btn.interactable = false;
        automatic.interactable = true;
        cc.SetPointer();
    }

    public void SetAutomatic()
    {
        obs.SetAutomatic();
        manual.interactable = true;
        btn.interactable = false;
        cc.SetPointer();
    }

    public void ConfirmYes()
    {
        obs.TriggerYes();
    }

    public void ConfirmNo()
    {
        obs.TriggerNo();
    }

    public void OnHover()
    {
        hintText.SetActive(true);
        if (btn.interactable)
        {
            cc.SetHand();
        }
        else
        {
            cc.SetPointer();
        }
    }

    public void OnExit()
    {
        hintText.SetActive(false);
        cc.SetPointer();
    }
}
