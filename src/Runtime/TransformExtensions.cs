using System;
using UnityEngine;

namespace flexington.Tools
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Determines whether the specified transform is visible within the given camera's view.
        /// </summary>
        /// <param name="transform">The transform to check for visibility.</param>
        /// <param name="camera">The camera used to determine visibility.</param>
        /// <param name="offset">Optional offset to adjust the visibility area.</param>
        /// <returns><c>true</c> if the transform is visible; otherwise, <c>false</c>.</returns>
        public static bool IsVisible(this Transform transform, Camera camera, Nullable<Rect> offset = null)
        {
            if (offset == null) offset = Rect.zero;
            var screenPosition = camera.WorldToScreenPoint(transform.position);
            Rect screenRect = new Rect(0 + offset.Value.x, 0 + offset.Value.y, Screen.width - offset.Value.width, Screen.height - offset.Value.height);
            return screenRect.Contains(screenPosition);
        }
    }
}