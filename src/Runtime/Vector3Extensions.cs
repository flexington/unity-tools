using UnityEngine;

namespace flexington.Tools
{
    /// <summary>
    /// Provides extension methods for the Vector3 class.
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        /// Converts a Vector3 to a Vector2 by discarding the z component.
        /// </summary>
        /// <param name="vector">The Vector3 to convert.</param>
        /// <returns>A new Vector2 with the x and y components of the input Vector3.</returns>
        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }
    }
}