using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGHighlighter : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    private float top;
    private float bottom;
    private float left;
    private float right;
    private RectTransform rt;
    private Image img;



    void Start()
    {
        rt = GetComponent<RectTransform>();
        top = transform.position.y + rt.rect.height;
        bottom = transform.position.y - rt.rect.height;
        left = transform.position.x - rt.rect.width;
        right = transform.position.x + rt.rect.width;
        img = GetComponent<Image>();
    }

    void Update()
    {
        mouseX = Input.mousePosition.x / Screen.width * 800.0f - 400.0f;
        mouseY = Input.mousePosition.y / Screen.height * 450.0f - 225.0f;
        Debug.Log(mouseX + "\n" + mouseY + "\n" + top + "\n" + bottom + "\n" + left + "\n" + right);
        if (bottom < mouseY && mouseY < top && left < mouseX && mouseX < right)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
        }
        else
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
        }
    }
}
