using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace flexington.Tools
{
    /// <summary>
    /// Provides extension methods for the <see cref="Tilemap"/> class.
    /// </summary>
    public static class TilemapExtensions
    {
        /// <summary>
        /// Returns the size of filled tilemap.
        /// </summary>
        /// <param name="tilemap">The tilemap to get the size of.</param>
        /// <returns>A <see cref="RectInt"/> representing the size of the tilemap.</returns>
        public static RectInt Size(this Tilemap tilemap)
        {
            var cellBound = new Vector2Int(tilemap.cellBounds.size.x, tilemap.cellBounds.size.y);
            var tiles = tilemap.GetTilesBlock(tilemap.cellBounds);

            Nullable<Vector2Int> bottomLeft = null;
            int width = 0;
            int height = 0;

            for (int y = 0; y < cellBound.y; y++)
            {
                for (int x = 0; x < cellBound.x; x++)
                {
                    var index = y * cellBound.x + x;
                    var tile = tiles[index];
                    if (tile == null) continue;

                    if (bottomLeft == null) bottomLeft = new Vector2Int(x, y);
                    if (x > width) width = x;
                    if (y > height) height = y;
                }
            }

            width = width - bottomLeft.Value.x + 1;
            height = height - bottomLeft.Value.y + 1;

            return new RectInt(bottomLeft.Value.x, bottomLeft.Value.y, width, height);
        }

        public static T[,] GetTilesGrid<T>(this Tilemap tilemap)
        {
            var allTiles = tilemap.GetTilesBlock(tilemap.cellBounds).Cast<T>().ToArray();
            var size = tilemap.Size();

            var grid = new T[size.width, size.height];


            for (int y = size.y; y < size.yMax; y++)
            {
                for (int x = size.x; x < size.xMax; x++)
                {
                    try
                    {
                        var index = (y * size.width) + (y * size.x) + x;
                        grid[x - size.xMin, y - size.yMin] = allTiles[index];
                    }
                    catch (System.Exception e)
                    {
                        Debug.Log(new Vector2Int(x, y));
                        Debug.LogException(e);
                        throw;
                    }
                }
            }

            return grid;
        }
    }
}