using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class SpriteCornerFinder : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            Bounds spriteBounds = spriteRenderer.bounds;

            Vector3 bottomLeft = new Vector3(spriteBounds.min.x, spriteBounds.min.y, transform.position.z);
            Vector3 bottomRight = new Vector3(spriteBounds.max.x, spriteBounds.min.y, transform.position.z);
            Vector3 topLeft = new Vector3(spriteBounds.min.x, spriteBounds.max.y, transform.position.z);
            Vector3 topRight = new Vector3(spriteBounds.max.x, spriteBounds.max.y, transform.position.z);

            Debug.Log($"Bottom Left: {bottomLeft}");
            Debug.Log($"Bottom Right: {bottomRight}");
            Debug.Log($"Top Left: {topLeft}");
            Debug.Log($"Top Right: {topRight}");
        }
    }
}
