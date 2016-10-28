using UnityEngine;
using System.Collections;

public static class TextureGenerator{

    ///<summary>
    ///Generates a texture from a given colourMap.
    ///</summary>
    ///<param name="colourMap">The Color array to be turned into a texture.</param>
    ///<param name="width">Width of the texture to be generated.</param>
    ///<param name="height">Height of the texture to be generated.</param>
    ///<remarks>The actual colourMap is generated elsewhere. For colourMaps with actual color, they are generated
    ///in MapGenerator.cs. For colourMaps that make BW textures, they are generated in the TextureFromHeightMap method below. </remarks>
    ///<returns>A texture to be rendered by Mapdisplay.DrawTexture.</returns>
    public static Texture2D TextureFromColourMap(Color[] colourMap, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point;                      //Set distinct color for each map coordinate
        texture.wrapMode = TextureWrapMode.Clamp;                   //Prevent Texture from wrapping.
        texture.SetPixels(colourMap);
        texture.Apply();
        return texture;
    }

    ///<summary>
    ///Generates a BW texture from a given heightMap.
    ///</summary>
    ///<param name="heightMap">The float array to be turned into a texture.</param>
    ///<returns>A texture to be rendered by Mapdisplay.DrawTexture.</returns>
    public static Texture2D TextureFromHeightMap(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        //Generate BW colourMap from heightmap.
        Color[] colourMap = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }
        texture.SetPixels(colourMap);
        texture.Apply();

        return TextureFromColourMap(colourMap, width, height);      
    }

}
