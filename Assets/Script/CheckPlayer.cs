using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckPlayer : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (tilemap != null)
            {
                TilemapRenderer tileRender = tilemap.GetComponent<TilemapRenderer>();
                if (tileRender != null)
                {
                    Destroy(tileRender.gameObject);
                }
                Destroy(tilemap);

            }
        }
    }
}
