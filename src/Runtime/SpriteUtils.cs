using System.Text;
using UnityEngine;

namespace flexington.Tools
{
    /// <summary>
    /// Utility class for working with Sprites.
    /// </summary>
    public static class SpriteUtils
    {
        /// <summary>
        /// Returns the Texture2D representation of a Sprite.
        /// </summary>
        /// <param name="sprite">The Sprite to convert.</param>
        /// <returns>The converted Texture2D.</returns>
        public static Texture2D ToTexture2D(this Sprite sprite)
        {
            var texture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            var pixels = sprite.texture.GetPixels((int)sprite.textureRect.x,
                (int)sprite.textureRect.y,
                (int)sprite.textureRect.width,
                (int)sprite.textureRect.height);
            texture.SetPixels(pixels);
            texture.Apply();
            return texture;
        }

        /// <summary>
        /// Converts a 2D array of Sprites into a Texture2D.
        /// </summary>
        /// <param name="sprites">The 2D array of Sprites to convert.</param>
        /// <returns>The converted Texture2D.</returns>
        public static Texture2D ToTexture2D(this Sprite[,] sprites)
        {
            Vector2Int spriteSize = new Vector2Int((int)sprites[0, 0].rect.width, (int)sprites[0, 0].rect.height);
            Vector2Int textureSize = new Vector2Int(spriteSize.x * sprites.GetLength(0), spriteSize.y * sprites.GetLength(1));

            var texture = new Texture2D(textureSize.x, textureSize.y);
            for (int px = 0; px < sprites.GetLength(0); px++)
            {
                for (int py = 0; py < sprites.GetLength(1); py++)
                {
                    var sprite = sprites[px, py];
                    var pixels = sprite.texture.GetPixels((int)sprite.rect.x,
                        (int)sprite.rect.y,
                        (int)sprite.rect.width,
                        (int)sprite.rect.height);
                    texture.SetPixels(px * spriteSize.x, py * spriteSize.y, spriteSize.x, spriteSize.y, pixels);
                    texture.Apply();
                }
            }
            return texture;
        }

        /// <summary>
        /// Returns a rect describing the position of the sprite in the current world.
        /// Use xMin, yMin and xMax and yMax of the returned rect to get the 2D world coorindinates of the sprite.
        /// </summary>
        public static Rect GetWorldRect(Transform transform, Sprite sprite)
        {
            float ppu = sprite.pixelsPerUnit;

            Rect rect = sprite.rect;
            rect.xMax /= ppu;
            rect.yMax /= ppu;
            Vector2 pivot = sprite.pivot / ppu;

            float x = rect.xMax * pivot.x;
            float y = rect.yMax * pivot.y;

            Rect spriteRect = new Rect();
            spriteRect.xMin = transform.position.x - x;
            spriteRect.xMax = transform.position.x + x;
            spriteRect.yMin = transform.position.y - y;
            spriteRect.yMax = transform.position.y + y;

            return spriteRect;
        }

        /// <summary>
        /// Converts the given WorldPosition into the corresponding pixel position of the given sprite.
        /// </summary>
        /// <param name="worldPosition">The world position as a Vector2</param>
        /// <param name="transform">The transform of the game object that holds the sprite</param>
        /// <param name="sprite">The spite iteself</param>
        /// <returns>The X,Y coordinates of the closest pixel</returns>
        /// <todo>The actual selected Pixel is one pixel above the curser</todo>
        public static Vector2 WorldToPixelCoordinates(Vector2 worldPosition, Transform transform, Sprite sprite)
        {
            // Change coordinates to local coordinates of this image
            Vector3 localPosition = transform.InverseTransformPoint(worldPosition);

            // Change these to coordinates of pixels
            float pixelWidth = sprite.rect.width;
            float pixelHeight = sprite.rect.height;
            float unitsToPixels = pixelWidth / sprite.bounds.size.x * transform.localScale.x;

            // Need to center our coordinates
            float centered_x = localPosition.x * unitsToPixels + pixelWidth / 2;
            float centered_y = localPosition.y * unitsToPixels + pixelHeight / 2;

            // Round current mouse position to nearest pixel
            Vector2 pixel_pos = new Vector2(Mathf.RoundToInt(centered_y), Mathf.RoundToInt(centered_x));

            return pixel_pos;
        }
    }
}