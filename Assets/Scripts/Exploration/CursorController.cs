using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    
    //[SerializeField]
    public Texture2D normalCursor;
    //[SerializeField]
    public Texture2D moveCursor;
    //[SerializeField]
    public Texture2D wallCursor;

    public static CursorController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SetNormalCursor()
    {
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetMoveCursor()
    {
        Cursor.SetCursor(moveCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetWallCursor()
    {
        Cursor.SetCursor(wallCursor, Vector2.zero, CursorMode.Auto);
    }
}
