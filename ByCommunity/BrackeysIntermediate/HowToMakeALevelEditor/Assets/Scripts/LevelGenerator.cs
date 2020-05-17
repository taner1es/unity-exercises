using System;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for(int x = 0; x < map.width; x++)
        {
            for(int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    private void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        // ignore transparent pixels
        if (pixelColor.a == 0)
            return;

        foreach(ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Instantiate(colorMapping.prefab, new Vector2(x, y), Quaternion.identity, transform);
            }
        }
        
    }
}
