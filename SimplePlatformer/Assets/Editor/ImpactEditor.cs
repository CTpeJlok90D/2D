using UnityEditor;

[CustomEditor(typeof(Impact))]
public class ImpactInspector : Editor
{
    private SerializedProperty _stun;
    private SerializedProperty _stunImmunitete;
    private SerializedProperty _invulnerability;
    private SerializedProperty _speedMultiplier;
    private SerializedProperty _jumpForseMultiplier;
    private SerializedProperty _healValue;
    private SerializedProperty _kick;

    private void OnEnable()
    {
        _stun = serializedObject.FindProperty("Stun");
        _stunImmunitete = serializedObject.FindProperty("StunImmunitete");
        _invulnerability = serializedObject.FindProperty("Invulnerability");
        _speedMultiplier = serializedObject.FindProperty("SpeedMultiplier");
        _jumpForseMultiplier = serializedObject.FindProperty("JumpForseMultiplier");
        _healValue = serializedObject.FindProperty("HealValue");
        _kick = serializedObject.FindProperty("Kick");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_stun);
        EditorGUILayout.PropertyField(_stunImmunitete);
        EditorGUILayout.PropertyField(_invulnerability);
        EditorGUILayout.PropertyField(_speedMultiplier);
        EditorGUILayout.PropertyField(_jumpForseMultiplier);
        EditorGUILayout.PropertyField(_healValue);
        EditorGUILayout.PropertyField(_kick);

        serializedObject.ApplyModifiedProperties();
    }
}