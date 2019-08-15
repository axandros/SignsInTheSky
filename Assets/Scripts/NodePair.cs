using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[Serializable]
class NodePair
{
    public NodeMapper Node = null;
    public bool Connection = false;
}

[CustomPropertyDrawer(typeof(NodePair))]
public class NodePairDrawer : PropertyDrawer
{
    //TODO: Fill out Drawer
    //https://catlikecoding.com/unity/tutorials/editor/custom-data/
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PrefixLabel(position, label);
        EditorGUI.PropertyField(position, property.FindPropertyRelative("position"));
    }
}