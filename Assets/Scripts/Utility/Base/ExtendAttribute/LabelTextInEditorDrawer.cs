﻿using UnityEditor;
using UnityEngine;

namespace Utility.Base.ExtendAttribute
{
    [CustomPropertyDrawer(typeof(LabelTextInEditorAttribute))]
    public class LabelTextInEditorDrawer : PropertyDrawer

    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label.text = ((LabelTextInEditorAttribute)attribute).Label;
            EditorGUI.PropertyField(position, property, label, true);
        }
    }
}