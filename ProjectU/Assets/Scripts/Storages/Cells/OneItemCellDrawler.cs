using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(OneItemCellRootParametrs))]
public class OneItemCellRootParametrsEditor : Editor
{
    private SerializedProperty _parametr1;
    private SerializedProperty _parametr2;

    public void OnEnable()
    {
        _parametr1 = serializedObject.FindProperty("Position");
        _parametr2 = serializedObject.FindProperty("Size");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_parametr1);
        EditorGUILayout.PropertyField(_parametr2);
        serializedObject.ApplyModifiedProperties();
    }
}
