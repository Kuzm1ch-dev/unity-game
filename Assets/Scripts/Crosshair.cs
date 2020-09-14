using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Vector2 size;
    public Texture2D crosshair;
   void OnGUI()
    {
        
        GUI.DrawTexture(new Rect(Screen.width/2 - size.x/2,Screen.height/2 - size.y/2, size.x, size.y),crosshair);
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
