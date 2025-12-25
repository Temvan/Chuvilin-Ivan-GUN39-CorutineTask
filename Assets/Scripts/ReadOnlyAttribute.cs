using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Блокирует возможность редактирования поля в инспекторе Unity.
/// </summary>

public class ReadOnlyAttribute : PropertyAttribute {}

#if UNITY_EDITOR

[UnityEditor.CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyPropertyDrawer : UnityEditor.PropertyDrawer
{
    // Для старой отрисовки инспектора

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label);
        GUI.enabled = true;
    }

    // Для новой отрисовки инспектора

    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var element = base.CreatePropertyGUI(property)
        ?? new UnityEditor.UIElements.PropertyField(property);
        element.SetEnabled(false);
        return element;
    }
}
#endif