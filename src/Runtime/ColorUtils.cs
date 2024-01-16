using System;
using UnityEngine;

namespace flexington.Tools
{
    /// <summary>
    /// Color utility class.
    /// </summary>
    public static class ColorUtils
    {
        /// <summary>
        /// Generates a random color.
        /// </summary>
        /// <returns>A random Color object.</returns>
        public static Color Random()
        {
            return Random(DateTime.Now.Ticks.ToString());
        }

        /// <summary>
        /// Generates a random color using the specified seed.
        /// </summary>
        /// <param name="seed">The seed used for generating the random color.</param>
        /// <returns>A random Color object.</returns>
        public static Color Random(string seed)
        {
            System.Random random = new System.Random(seed.GetHashCode());
            return new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
        }

        public static Color GetRandomColor()
        {
            return new Color(
                UnityEngine.Random.Range(0, 255) / 255f,
                UnityEngine.Random.Range(0, 255) / 255f,
                UnityEngine.Random.Range(0, 255) / 255f
            );
        }
    }
}