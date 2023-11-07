using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(DrawWire1))]
public class CostomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DrawWire1 myTarget= (DrawWire1)target;

        if(GUILayout.Button(" Give Random Value"))
        {
            myTarget.myint = 4;
        }
    }
}
