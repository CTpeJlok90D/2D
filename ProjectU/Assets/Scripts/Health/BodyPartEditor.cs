using UnityEditor;

public class BodyPartEditor : Editor
{
    private SerializedProperty _givingBoodLevelPerSecond;
    private SerializedProperty _filteringBloodPerSecond;
    private SerializedProperty _bloodPumping;
    private SerializedProperty _givingOxygen;
    private SerializedProperty _name;
    private SerializedProperty _storageOxygen;

    private void OnEnable()
    {
        _givingBoodLevelPerSecond = serializedObject.FindProperty("_givingBoodLevelPerSecond");
        _filteringBloodPerSecond = serializedObject.FindProperty("_filteringBloodPerSecond");
        _bloodPumping = serializedObject.FindProperty("_bloodPumping");
        _givingOxygen = serializedObject.FindProperty("_givingOxygen");
        _name = serializedObject.FindProperty("_name");
        _storageOxygen = serializedObject.FindProperty("_storageOxygen");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_givingBoodLevelPerSecond);
        EditorGUILayout.PropertyField(_filteringBloodPerSecond);
        EditorGUILayout.PropertyField(_bloodPumping);
        EditorGUILayout.PropertyField(_givingOxygen);
        EditorGUILayout.PropertyField(_name);
        EditorGUILayout.PropertyField(_storageOxygen);
        serializedObject.ApplyModifiedProperties();
    }
}