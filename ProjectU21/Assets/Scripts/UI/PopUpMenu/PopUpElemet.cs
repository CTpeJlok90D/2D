using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class PopUpElement 
{
    [SerializeField] private string _caption;
    [SerializeField] private UnityEvent _onClick;

    public string Caption => _caption;
    UnityEvent OnClick => _onClick;
}

[CustomEditor(typeof(PopUpElement))]
public class PopUpElementDrawer : Editor
{
    private SerializedProperty PopUpElement;

    public void OnEnable()
    {
        PopUpElement = serializedObject.FindProperty("_caption");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(PopUpElement);
        serializedObject.ApplyModifiedProperties();
    }
}