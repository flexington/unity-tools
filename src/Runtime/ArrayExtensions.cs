using System;

namespace flexington.Tools
{
    public static class ArrayExtensions
    {
        public static int Count<T>(this T[,] array, Func<T, bool> predicate)
        {
            int count = 0;
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    if (predicate(array[x, y])) count++;
                }
            }
            return count;
        }
    }
}