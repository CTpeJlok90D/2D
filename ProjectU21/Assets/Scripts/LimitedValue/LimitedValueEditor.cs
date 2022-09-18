using UnityEditor;

[CustomEditor(typeof(LimitedValueEditor))]
public class LimitedValueEditor : Editor
{
    private SerializedProperty _min;
    private SerializedProperty _max;
    private SerializedProperty _current;
    private void OnEnable()
    {
        _current = serializedObject.FindProperty("_current");
        _min = serializedObject.FindProperty("_min");
        _max = serializedObject.FindProperty("_max");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_max);
        EditorGUILayout.PropertyField(_min);
        EditorGUILayout.PropertyField(_current);
        serializedObject.ApplyModifiedProperties();
    }

    private void OnValidate()
    {
        
    }
}