using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Utility.Base.ExtendAttribute
{
    [CustomPropertyDrawer(typeof(BoxGroupInEditorAttribute))]
    public class BoxGroupInEditorDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var fields = property.serializedObject.targetObject.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in fields)
            {
                var boxGroupInEditorAttribute = field.GetCustomAttribute<BoxGroupInEditorAttribute>();
                if (boxGroupInEditorAttribute == null) continue;
                if (field.FieldType == typeof(int))
                {
                    field.SetValue(property.serializedObject.targetObject,
                        EditorGUILayout.IntField(field.Name,
                            (int)field.GetValue(property.serializedObject.targetObject)));
                }
                else if (field.FieldType == typeof(string))
                {
                    field.SetValue(property.serializedObject.targetObject,
                        EditorGUILayout.TextField(field.Name,
                            (string)field.GetValue(property.serializedObject.targetObject)));
                }
                //Todo: Add other type support
            }

            Draw($"{label}", property.serializedObject.targetObject);
        }

        private static void Draw(string title, object target)
        {
            GUILayout.BeginVertical("box");
            GUILayout.Label(title, EditorStyles.boldLabel);

            var fields = target.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in fields)
            {
                var boxGroupInEditorAttribute = field.GetCustomAttribute<BoxGroupInEditorAttribute>();
                if (boxGroupInEditorAttribute == null) continue;
                if (field.FieldType == typeof(int))
                {
                    field.SetValue(target, EditorGUILayout.IntField(field.Name, (int)field.GetValue(target)));
                }
                else if (field.FieldType == typeof(string))
                {
                    field.SetValue(target, EditorGUILayout.TextField(field.Name, (string)field.GetValue(target)));
                }
                //Todo: Add other type support
            }

            GUILayout.EndVertical();
        }
    }
}