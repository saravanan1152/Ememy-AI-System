using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GuiButton : EditorWindow
{
    [MenuItem("Window/sample")]
  
  
   
    public static void openWindow()
    {
        GetWindow<GuiButton>("sample");
    }
    private void OnGUI()
    {
        GUILayout.Label("MY Lable");

        if(GUILayout.Button("I am button"))
        {
            Debug.Log("Preas the Button");

        }
    }
}
