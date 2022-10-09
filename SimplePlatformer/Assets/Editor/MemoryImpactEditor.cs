using UnityEditor;
using AI.Memory;

[CustomEditor(typeof(Memory))]
internal class MemoryImpactEditor : Editor 
{
    private SerializedProperty _task;
    private SerializedProperty _coefficient;
    private SerializedProperty _dituration;

    private void OnEnable()
    {
        _task = serializedObject.FindProperty("_task");
        _coefficient = serializedObject.FindProperty("_coefficient");
        _dituration = serializedObject.FindProperty("_dituration");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_task);
        EditorGUILayout.PropertyField(_coefficient);
        EditorGUILayout.PropertyField(_dituration);

        serializedObject.ApplyModifiedProperties();
    }
}