using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

#region SelectAttribute
public class SelectAttribute : PropertyAttribute
{
    public object[] Values { get; private set; }
    public Type Type { get; private set; }

    public SelectAttribute(Type type, object[] values)
    {
        Type = type;
        Values = values;
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SelectAttribute))]
public class SelectDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var attribute = (SelectAttribute)this.attribute;
        int selectedIndex = 0;
        string[] displayOptions = attribute.Values.Select(x => x.ToString()).ToArray();

        if (property.propertyType == SerializedPropertyType.Integer)
        {
            selectedIndex = Array.IndexOf(displayOptions, property.intValue.ToString());
        }
        else if (property.propertyType == SerializedPropertyType.Float)
        {
            selectedIndex = Array.IndexOf(displayOptions, property.floatValue.ToString());
        }
        else if (property.propertyType == SerializedPropertyType.String)
        {
            selectedIndex = Array.IndexOf(displayOptions, property.stringValue);
        }

        selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, displayOptions);

        if (property.propertyType == SerializedPropertyType.Integer)
        {
            property.intValue = int.Parse(displayOptions[selectedIndex]);
        }
        else if (property.propertyType == SerializedPropertyType.Float)
        {
            property.floatValue = float.Parse(displayOptions[selectedIndex]);
        }
        else if (property.propertyType == SerializedPropertyType.String)
        {
            property.stringValue = displayOptions[selectedIndex];
        }
    }
}
#endif

#endregion SelectAttribute

#region SerializableDictionary
public class SerializableDictionaryAttribute : PropertyAttribute
{
}


#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SerializableDictionaryAttribute))]
public class SerializableDictionaryDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // Реалізуйте власну логіку відображення тут

        EditorGUI.EndProperty();
    }

}
#endif

#endregion SerializableDictionary


[CustomEditor(typeof(PlayerCtrls))]
public class ButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PlayerCtrls script = (PlayerCtrls)target;
        if (GUILayout.Button("Change camera transform"))
        {
            script.SetCameraData();
        }
    }
}
