using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorChange : MonoBehaviour
{
    private Vector2 hotspot;
    private CursorMode cursorMode;
    [SerializeField] private Texture2D hand;
    [SerializeField] private Texture2D glass;

    // Start is called before the first frame update
    void Start()
    {
        hotspot = Vector2.zero;
        cursorMode = CursorMode.Auto;
    }


    public void SetPointer()
    {
        ///Cursor.SetCursor(null, hotspot, cursorMode);
    }

    public void SetHand()
    {
        //Cursor.SetCursor(hand, hotspot, cursorMode);
    }

    public void SetGlass()
    {
        //Cursor.SetCursor(glass, hotspot, cursorMode);
    }
}
