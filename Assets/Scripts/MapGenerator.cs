using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

    public enum DrawMode {NoiseMap, ColourMap, Mesh}; //Enumeration to determine what form the map is drawn as.
    public DrawMode drawMode;

    public const int mapChunkSize = 241;       //Optimized to have the largest amount of vertices Unity allows in one Mesh, while still giving several LOD division options.
    
    [Range(0,6)]
    public int levelOfDetail;       //The LOD reduction factor. (The value of levelOfDetail is actually half the amount of map width indices skipped for generating the mesh.)
    public float noiseScale;        //How zoomed in the chunk is to the noiseMap.

    public int octaves;                     //How many octaves of noise to layer and sum.

    [Range(0, 1)]                           //Makes persistance a slider.      
    public float persistance;               //Controls decrease in amplitude of octaves.
    public float lacunarity;                //Controls increase in frequency of octaves.

    public int seed;
    public Vector2 offset;          //Allows scrolling of map.

    public float meshHeightMultiplier;      //Scalar for height of terrain.
    public AnimationCurve meshHeightCurve;  //Controls for terrain below sea level.

    public bool autoUpdate;         //Setting for: Should the map automatically regenerate if a setting is changed?

    public TerrainType[] regions;   //An array that holds objects for the different height regions.

    /// <summary>
    /// Generates the map at game runtime.
    /// </summary>
    void Start()
    {
        GenerateMap();
    }

    ///<summary>
    ///Generates the map texture via a noiseMap or a colourMap. Acts as user-interface in the Unity Inspector panel.
    ///</summary>
    ///<remarks>
    ///Whether a noiseMap or colourMap is generated is determined by the DrawMode setting set in the Unity Inspector.
    ///</remarks>
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap (mapChunkSize,mapChunkSize, seed, noiseScale, octaves, persistance, lacunarity, offset);

        //Detecting height and assigning colour.
        Color[] colourMap = new Color[mapChunkSize*mapChunkSize];
        for (int y = 0; y < mapChunkSize; y++)     //loop through y coordinates of map.
        {
            for (int x = 0; x < mapChunkSize; x++)  //loop through x coordinates of map.
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)                    //Judging color by comparing height value to each region's bounds.
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colourMap[y * mapChunkSize + x] = regions[i].colour;    //[y * mapwidth + x] is a 2D array to 1D array mapping. 
                        break;
                    }
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();
        if (drawMode == DrawMode.NoiseMap)                      //Depending on Draw Mode setting in inspector, generate a BW texture from heightMap, color texture by colourMap, or Mesh from the Map data.
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColourMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapChunkSize, mapChunkSize));
        } 
        else if (drawMode == DrawMode.Mesh)
        {
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve, levelOfDetail), TextureGenerator.TextureFromColourMap(colourMap, mapChunkSize, mapChunkSize));
        }
    }

    //Set boundaries on input values in Inspector panel.
    void OnValidate()
    {
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
