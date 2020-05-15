using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observer : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    private Vector2 hotspot;
    private CursorMode cursorMode;

    public GameObject leftHL;
    public GameObject rightHL;
    public Button defaultButton;
    public Texture2D hand;
    public Texture2D glass;
    public Text title;
    public Text summary;
    public Text fullInfo;
    public Image preview;

    // Start is called before the first frame update
    void Start()
    {
        hotspot = Vector2.zero;
        cursorMode = CursorMode.Auto;
        defaultButton.onClick.Invoke();
    }

    private void Update()
    {
        mouseX = Input.mousePosition.x / Screen.width * 800.0f - 400.0f;
        mouseY = Input.mousePosition.y / Screen.height * 450.0f - 225.0f;
        Debug.Log(mouseX);

        leftHL.SetActive(false);
        rightHL.SetActive(false);
        if (-218.0f < mouseY && mouseY < 218.0f)
        {
            if (-393.0f < mouseX && mouseX < -139.0f)
            {
                leftHL.SetActive(true);
            }
            else if (-131.0f < mouseX && mouseX < 393.0f)
            {
                rightHL.SetActive(true);
            }
        }
    }

    /* Update Info Pane */
    public void UpdateInfo(string ttl, string summ, string fInfo, Sprite prev)
    {
        title.text = ttl;
        summary.text = summ;
        //fullInfo.text = fInfo;
        preview.sprite = prev;
    }

    /*********************/
    /* Cursor Management */
    /*********************/
    public void SetPointer()
    {
        Cursor.SetCursor(null, hotspot, cursorMode);
    }

    public void SetHand()
    {
        Cursor.SetCursor(hand, hotspot, cursorMode);
    }

    public void SetGlass()
    {
        Cursor.SetCursor(glass, hotspot, cursorMode);
    }
}
