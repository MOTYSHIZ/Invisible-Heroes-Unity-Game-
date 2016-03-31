using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

    public enum DrawMode {NoiseMap, ColourMap}; //Enumeration to determine what kind of texture is drawn.
    public DrawMode drawMode;

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;                     //How many octaves of noise to layer and sum.

    [Range(0, 1)]                           //Makes persistance a slider.      
    public float persistance;               //Controls decrease in amplitude of octaves.
    public float lacunarity;                //Controls increase in frequency of octaves.

    public int seed;
    public Vector2 offset;          //Allows scrolling of map.

    public bool autoUpdate;         //Should the map automatically regenerate if a setting is changed?

    public TerrainType[] regions;  

    ///<summary>
    ///Generates the map texture via a noiseMap or a colourMap. Acts as user-interface in the Unity Inspector panel.
    ///</summary>
    ///<remarks>
    ///Whether a noiseMap or colourMap is generated is determined by the DrawMode setting set in the Unity Inspector.
    ///</remarks>
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth,mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        //Detecting height and assigning colour.
        Color[] colourMap = new Color[mapWidth*mapHeight];
        for (int y = 0; y < mapHeight; y++)     //loop through y coordinates of map.
        {
            for (int x = 0; x < mapWidth; x++)  //loop through x coordinates of map.
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)                    //Judging color by comparing height value to each region's bounds.
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colourMap[y * mapWidth + x] = regions[i].colour;    //[y * mapwidth + x] is a 2D array to 1D array mapping. 
                        break;
                    }
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();
        if (drawMode == DrawMode.NoiseMap)                      //Depending on Draw Mode setting in inspector, generate a BW texture from heightMap, or color texture by colourMap
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColourMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
        }
        
    }

    //Set boundaries on input values in Inspector panel.
    void OnValidate()
    {
        if (mapWidth < 1) mapWidth = 1;
        if (mapHeight < 1) mapHeight = 1;
        if (lacunarity < 1) lacunarity = 1;
        if (octaves < 0) octaves = 0;
    }

    // A TerrainType for each height color level.
    [System.Serializable]
    public struct TerrainType
    {
        public string name;
        public float height;
        public Color colour;
    }
}
