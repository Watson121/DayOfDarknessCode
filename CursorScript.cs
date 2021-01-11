using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public bool Visible;

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = Visible;
    }
}
