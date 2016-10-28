using UnityEngine;
using System.Collections;

/// <summary>
/// An interface for the Map Generator game object to specify which plane to render the heightMap texture on and 
/// which mesh to generate the map topography on.
/// </summary>
public class MapDisplay : MonoBehaviour {

    public Renderer textureRender;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    /// <summary>
    /// Draws given Texture2D to given textureRender plane.
    /// </summary>
    /// <param name="texture"></param>
    public void DrawTexture(Texture2D texture)
    {
        textureRender.sharedMaterial.mainTexture = texture;
        textureRender.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }

    /// <summary>
    /// Sets the Mesh data for an input Mesh.
    /// </summary>
    /// <param name="meshData">Data to create the Mesh.</param>
    /// <param name="texture">Texture for the Mesh.</param>
    public void DrawMesh(MeshData meshData, Texture2D texture)
    {
        meshFilter.sharedMesh = meshData.CreateMesh();
        meshRenderer.sharedMaterial.mainTexture = texture;
    }
}
