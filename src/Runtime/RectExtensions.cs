using UnityEngine;

namespace flexington.Tools
{
    /// <summary>
    /// Extension methods for the Rect struct.
    /// </summary>
    public static class RectExtensions
    {
        /// <summary>
        /// Draws the outline of the Rect using Debug.DrawLine.
        /// </summary>
        /// <param name="rect">The Rect to draw.</param>
        /// <param name="color">The color of the lines.</param>
        /// <param name="duration">The duration of the lines in seconds.</param>
        public static void DebugDraw(this Rect rect, Color color, float duration = 0)
        {
            Debug.DrawLine(rect.min, rect.min + new Vector2(rect.width, 0), color, duration);
            Debug.DrawLine(rect.min, rect.min + new Vector2(0, rect.height), color, duration);
            Debug.DrawLine(rect.max, rect.max - new Vector2(rect.width, 0), color, duration);
            Debug.DrawLine(rect.max, rect.max - new Vector2(0, rect.height), color, duration);
        }
    }
}