using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;                     //How many octaves of noise to layer and sum.
    [Range(0, 1)]                           //Make persistance a slider.      
    public float persistance;               //Controls decrease in amplitude of octaves.
    public float lacunarity;                //Controls increase in frequency of octaves.

    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth,mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }

    //Set boundaries on input values in Inspector panel.
    void OnValidate()
    {
        if (mapWidth < 1) mapWidth = 1;
        if (mapHeight < 1) mapHeight = 1;
        if (lacunarity < 1) lacunarity = 1;
        if (octaves < 0) octaves = 0;
    }
}
