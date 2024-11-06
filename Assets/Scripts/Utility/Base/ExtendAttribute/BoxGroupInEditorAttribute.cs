using UnityEngine;
using System;
using System.Diagnostics;

namespace Utility.Base.ExtendAttribute
{
    [Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.All)]
    public class BoxGroupInEditorAttribute : PropertyAttribute
    {
        public string Title { get; }

        public BoxGroupInEditorAttribute(string title)
        {
            Title = title;
        }
    }
}