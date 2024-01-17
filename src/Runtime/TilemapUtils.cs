using UnityEngine;
using UnityEngine.Tilemaps;

namespace flexington.Tools
{
    public static class TilemapUtils
    {
        public static Tilemap CreateTilemap(string name, GridLayout parent, int orderInLayer = 0, bool hasCollider = true, bool isTrigger = true)
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent.transform);
            go.transform.localPosition = Vector3.zero;
            var tilemap = go.AddComponent<Tilemap>();
            var renderer = go.AddComponent<TilemapRenderer>();
            renderer.sortingOrder = orderInLayer;

            if (hasCollider)
            {
                var collider = go.AddComponent<TilemapCollider2D>();
                collider.isTrigger = isTrigger;
            }

            return tilemap;
        }
    }
}