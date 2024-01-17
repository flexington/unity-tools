using System;
using UnityEngine;

namespace flexington.Tools
{
    public static class Vector2Extensions
    {
        /// <summary>
        /// Determines whether the specified position is visible within the given camera's view.
        /// </summary>
        /// <param name="position">The position to check for visibility.</param>
        /// <param name="camera">The camera used to determine visibility.</param>
        /// <param name="offset">Optional offset to adjust the visibility area.</param>
        /// <returns><c>true</c> if the position is visible; otherwise, <c>false</c>.</returns>
        public static bool IsInView(this Vector2 position, Camera camera, Nullable<Rect> offset = null)
        {
            if (offset == null) offset = Rect.zero;
            var screenPosition = camera.WorldToScreenPoint(position);
            Rect screenRect = new Rect(0 + offset.Value.x, 0 + offset.Value.y, Screen.width + offset.Value.width, Screen.height + offset.Value.height);
            return screenRect.Contains(screenPosition);
        }

        /// <summary>
        /// Caps the given Vector2 to the given rect.
        /// </summary>
        /// <param name="vector">The vector to cap.</param>
        /// <param name="rect">The rect to cap the vector to.</param>
        /// <returns>The capped vector.</returns>
        public static Vector2 Cap(this Vector2 vector, Rect rect)
        {
            return new Vector2(Mathf.Clamp(vector.x, rect.xMin, rect.xMax), Mathf.Clamp(vector.y, rect.yMin, rect.yMax));
        }
    }
}