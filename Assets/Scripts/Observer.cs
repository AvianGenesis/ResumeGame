using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observer : MonoBehaviour
{
    private Vector2 hotspot;
    private CursorMode cursorMode;

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
