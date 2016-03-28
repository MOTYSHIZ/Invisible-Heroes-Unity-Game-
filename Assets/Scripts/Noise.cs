///<summary>
///This class utilizes Unity's built-in Perlin Noise generator to generate the noiseMap 
///used by MapGenerator.cs.
///</summary>


using UnityEngine;
using System.Collections;

public class Noise {

    ///<summary>
    ///The method that generates the noiseMap. 
    ///</summary>
    ///<param name="mapWidth">Width of noiseMap</param>
    ///<param name="mapHeight">Height of noiseMap</param>
    ///<param name="seed">Seed for random generation. If the same seed is used with the same co-paramters,
    ///then the same map will be generated. If varied, this parameter allows maps with the same properties 
    ///to generate different maps.</param>
    ///<param name="scale">The Scale of the noiseMap. Essentially zooms into the center of the map as its
    ///value is increased.</param>
    ///<param name="octaves">The amount of octaves to be summed up to form the noiseMap</param>
    ///<param name="persistance">Controls decrease in amplitude of octaves.</param>
    ///<param name="lacunarity">Controls increase in frequency of octaves.</param>
    ///<param name="offset">Enables ability to scroll through the noise for the noiseMap.</param>
    ///<remarks>
    ///Called by MapGenerator.generateMap.
    ///</remarks>
    ///<returns>A 2D float array to the different heights in the map at each coordinate.</returns>
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, 
        float scale, int octaves, float persistance, float lacunarity, Vector2 offset) 
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];         //initializing noisemap to be returned.

        //Utilize seed to offset points where each noise octave samples from.
        System.Random prng = new System.Random(seed);        //prng : "Psuedo-random number generator"       
        Vector2[] octaveOffsets = new Vector2[octaves];      //offset values to be added to each octave
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offset.x;      //Arbitrary domain, but limits are necessary.
            float offsetY = prng.Next(-100000, 100000) + offset.y;      //offset.x and offset.y added to enable map scrolling.
            octaveOffsets[i] = new Vector2(offsetX, offsetY);     
        }

        if (scale <= 0) scale = 0.0001f;        //Doesn't allow the noiseMap scale to be less than 0.

        float maxNoiseHeight = float.MinValue;      //set to float.MinValue so it can be compared later for real max
        float minNoiseHeight = float.MaxValue;      //set to float.MaxValue so it can be compared later for real min

        //Find center of map to set as scaling anchor point.
        float halfWidth = mapWidth / 2f;    
        float halfHeight = mapHeight / 2f;

        for (int y = 0; y < mapHeight; y++)                     //Loop for noiseMap Y values
        {
            for (int x = 0; x < mapWidth; x++)                  //Loop for noiseMap X values
            {
                float amplitude = 1;                //amplitude is reset to 1 for each first octave per point
                float frequency = 1;                //frequency is reset to 1 for each first octave per point
                float noiseHeight = 0;              //noiseHeight is reset to 0 for each first octave per point

                for (int i = 0; i < octaves; i++)        //Loop for each octave of noise for a point on the map.
                {
                    float sampleX = (x-halfWidth) / scale * frequency + octaveOffsets[i].x; 
                    float sampleY = (y-halfHeight) / scale * frequency + octaveOffsets[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;  //"*2 - 1" to allow for negative values
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistance;       //amplitude decreases per octave (since persistance < 1)
                    frequency *= lacunarity;        //lacunarity increases per octave
                }

                //Get the current maxNoiseHeight and minNoiseHeight for normalization of height values.
                if(noiseHeight > maxNoiseHeight){                   
                    maxNoiseHeight = noiseHeight;               
                } else if(noiseHeight < minNoiseHeight){
                    minNoiseHeight = noiseHeight;
                }

                noiseMap[x, y] = noiseHeight;
            }
        }

        //Looping through all of the noiseMap values and normalizing each.
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                noiseMap[x,y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x,y]);
            }
        }

        return noiseMap;
    }
}
