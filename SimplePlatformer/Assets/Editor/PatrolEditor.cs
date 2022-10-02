using UnityEditor;
using AI.Tasks;

[CustomEditor(typeof(Patrol))]
internal class PatrolEditor : Editor
{
    private SerializedProperty _points;
    private SerializedProperty _mover;

    private void OnEnable()
    {
        _points = serializedObject.FindProperty("_patrolPoints");
        _mover = serializedObject.FindProperty("_mover");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_points);
        EditorGUILayout.PropertyField(_mover);

        serializedObject.ApplyModifiedProperties();
    }
}