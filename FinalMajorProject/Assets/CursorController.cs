using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Tilemaps;

public partial class CursorController : MonoBehaviour
{
    public DualGridTilemap dualGridTilemap;

    [Header("Input Settings")]
    public KeyCode placeDirtKey = KeyCode.Mouse0;
    public KeyCode placeGrassKey = KeyCode.Mouse1;

    void Update()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3Int tilePos = GetWorldPosTile(mouseWorldPos);
        transform.position = tilePos + new Vector3(0.5f, 0.5f, -1);

        if (Input.GetKey(placeDirtKey))
        {
            dualGridTilemap.SetCell(tilePos, dualGridTilemap.dirtPlaceholderTile);
        }

        if (Input.GetKey(placeGrassKey))
        {
            dualGridTilemap.SetCell(tilePos, dualGridTilemap.grassPlaceholderTile);
        }
    }

    public static Vector3Int GetWorldPosTile(Vector3 worldPos)
    {
        int xInt = Mathf.FloorToInt(worldPos.x);
        int yInt = Mathf.FloorToInt(worldPos.y);
        return new Vector3Int(xInt, yInt, 0);
    }
}