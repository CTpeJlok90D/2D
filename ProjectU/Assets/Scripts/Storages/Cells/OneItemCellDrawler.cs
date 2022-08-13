using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(OneItemCellRootParametrs))]
public class OneItemCellRootParametrsEditor : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        VisualElement container = new();

        container.Add(new PropertyField(property.FindPropertyRelative("Position")));
        container.Add(new PropertyField(property.FindPropertyRelative("Size")));

        return container;
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);


        Rect positionRect = new(position.x, position.y + 20, position.width - 90, position.height);
        Rect positionRectLabel = new(20, position.y, position.width - 90, position.height);
        Rect sizeRect = new(position.x, position.y + 40, position.width - 90, position.height);
        Rect sizeRectLabel = new(20, position.y + 20, position.width - 90, position.height);

        EditorGUI.PropertyField(positionRect, property.FindPropertyRelative("Position"), GUIContent.none);
        EditorGUI.PropertyField(sizeRect, property.FindPropertyRelative("Size"), GUIContent.none);

        EditorGUI.indentLevel++;
        EditorGUI.LabelField(positionRectLabel, "Position");
        EditorGUI.LabelField(sizeRectLabel, "Size");
        EditorGUI.indentLevel--;

        EditorGUI.EndProperty();
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int lineCount = 3;
        return EditorGUIUtility.singleLineHeight * lineCount + EditorGUIUtility.standardVerticalSpacing * lineCount - 1;
    }
}
