using System;
using UnityEngine;

namespace flexington.Tools
{
    public class VerticalGroup : IDisposable
    {
        private readonly bool _hasRightSpace;

        public VerticalGroup(bool hasLeftSpace = false, bool hasRightSpace = false, params GUILayoutOption[] options)
        {
            _hasRightSpace = hasRightSpace;
            if (hasLeftSpace) GUILayout.FlexibleSpace();
            GUILayout.BeginVertical(options);
        }

        public void Dispose()
        {
            GUILayout.EndVertical();
            if (_hasRightSpace) GUILayout.FlexibleSpace();
        }
    }

    public class HorizontalGroup : IDisposable
    {
        private readonly bool _hasSpace;

        public HorizontalGroup(bool hasSpace = false)
        {
            _hasSpace = hasSpace;
            if (_hasSpace) GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
        }

        public void Dispose()
        {
            GUILayout.EndHorizontal();
            if (_hasSpace) GUILayout.FlexibleSpace();
        }
    }

    public class ScrollGroup : IDisposable
    {
        public ScrollGroup(ref Vector2 scrollPosition)
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        }

        public ScrollGroup(ref Vector2 scrollPosition, params GUILayoutOption[] options)
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, options);
        }

        public void Dispose()
        {
            GUILayout.EndScrollView();
        }
    }

    public class Group : IDisposable
    {
        public Group(Rect rect)
        {
            GUILayout.BeginArea(rect);
        }

        public void Dispose()
        {
            GUILayout.EndArea();
        }
    }
}