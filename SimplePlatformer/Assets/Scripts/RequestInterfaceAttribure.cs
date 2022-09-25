using System;
using UnityEngine;
using UnityEditor;
public class RequireInterfaceAttribute : PropertyAttribute
{
    public Type requiredType { get; private set; }
    public RequireInterfaceAttribute(Type type)
    {
        requiredType = type;
    }
}

[CustomPropertyDrawer(typeof(RequireInterfaceAttribute))]
public class RequireInterfaceDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.ObjectReference)
        {
            RequireInterfaceAttribute requiredAttribute = attribute as RequireInterfaceAttribute;
            EditorGUI.BeginProperty(position, label, property);
            property.objectReferenceValue = EditorGUI.ObjectField(position, label, property.objectReferenceValue, requiredAttribute.requiredType, true);
            EditorGUI.EndProperty();
        }
        else
        {
            Color previousColor = GUI.color;
            GUI.color = Color.red;
            EditorGUI.LabelField(position, label, new GUIContent("Property is not a reference type"));
            GUI.color = previousColor;
        }
    }
}