using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ExplodeObject))]
public class ExplodeObjectInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ExplodeObject explodeObject = target as ExplodeObject;
        if (GUILayout.Button("Explode"))
        {
            explodeObject.Explode();
        }
    }
}
