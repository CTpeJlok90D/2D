using AI.Memory;
using UnityEditor;

[CustomEditor(typeof(MemoryDictionarity))]
public class MemoryDictionarityEditor : Editor
{
    private SerializedProperty _factor;
    private SerializedProperty _reaction;

    private void OnEnable()
    {
        _factor = serializedObject.FindProperty("_factor");
        _reaction = serializedObject.FindProperty("_reaction");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_factor);
        EditorGUILayout.PropertyField(_reaction);

        serializedObject.ApplyModifiedProperties();
    }
}