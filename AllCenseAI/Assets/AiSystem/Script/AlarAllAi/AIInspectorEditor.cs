
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

[CustomEditor(typeof(AlartAllAi))]
public class AIInspectorEditor : Editor
{


    #region

    SerializedProperty distance;
   
    SerializedProperty angle;
  
    SerializedProperty height;
 
   SerializedProperty scanFrequncy ;
  
    SerializedProperty _speed;

    SerializedProperty  allAISAlart;
    SerializedProperty  allSiteCense;
    SerializedProperty  faceSiteCense;
    #endregion

 /*  public override void OnInspectorGUI()
    {
     var script=(AlartAllAi)target;

        script.Events = EditorGUILayout.Toggle("Click:",script.Events);

        if (script.Events == false)
        {
            return;
        }
        script.enterTheAttackDistance = EditorGUILayout.BoundsField("Float", script.enterTheAttackDistance);
        script.g=EditorGUILayout.ObjectField("Gamobject",script.g,typeof(GameObject),true)as GameObject;
    }*/
}
