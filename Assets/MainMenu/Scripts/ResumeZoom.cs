﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeZoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float mouseOverPerc;
    private float mouseY;
    private bool mouseOver;
    private Observer obs;
    private GameObject highlight;
    private Transform resumeZoomTF;
    private CursorChange cc;

    public GameObject resumeZoomVP;

    void Start()
    {
        mouseOver = false;
        obs = GameObject.Find("Main Camera").GetComponent<Observer>();
        highlight = transform.GetChild(0).gameObject;
        cc = GetComponent<CursorChange>();
        resumeZoomTF = resumeZoomVP.transform.GetChild(0);
    }

    void Update()
    {
        if (mouseOver)
        {
            mouseY = Input.mousePosition.y / Screen.height * 450.0f - 225.0f;
            mouseOverPerc = (mouseY + 48.462f) / (66.322f + 48.462f);
            highlight.transform.localPosition = new Vector2(0.0f, Mathf.Lerp(-57.392f, 57.392f, mouseOverPerc));
            resumeZoomTF.localPosition = new Vector2(0.0f, Mathf.Lerp(124.08f, -124.08f, mouseOverPerc));
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cc.SetGlass();
        mouseOver = true;
        highlight.SetActive(true);
        resumeZoomVP.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cc.SetPointer();
        mouseOver = false;
        highlight.SetActive(false);
        resumeZoomVP.SetActive(false);
    }
}