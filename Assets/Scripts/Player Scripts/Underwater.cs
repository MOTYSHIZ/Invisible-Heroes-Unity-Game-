/*
 * Slightly modified from http://wiki.unity3d.com/index.php?title=Underwater_Script
*/

using UnityEngine;
using System.Collections;

public class Underwater : MonoBehaviour
{

    //This script enables underwater effects. Attach to main camera.

    //Define variable
    public int underwaterLevel;
    public Color underwaterFogColor;
    [Range(0,1)]
    public float underwaterFogDensity = 0.4f;
    
    //The scene's default fog settings
    private bool defaultFog;
    private Color defaultFogColor;
    private float defaultFogDensity;
    private Material defaultSkybox;
    private Material noSkybox = null;
    AudioSource aud;

    void Start()
    {
        //Set the background color
        GetComponent<Camera>().backgroundColor = new Color(0, 0.4f, 0.7f, 1);

        defaultFog = RenderSettings.fog;
        defaultFogColor = RenderSettings.fogColor;
        defaultFogDensity = RenderSettings.fogDensity;
        defaultSkybox = RenderSettings.skybox;
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.position.y < underwaterLevel)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = underwaterFogColor;
            RenderSettings.fogDensity = underwaterFogDensity;
            RenderSettings.skybox = noSkybox;
            
        }
        else
        {
            RenderSettings.fog = defaultFog;
            RenderSettings.fogColor = defaultFogColor;
            RenderSettings.fogDensity = defaultFogDensity;
            RenderSettings.skybox = defaultSkybox;
            aud.Play();
        }

    }
}