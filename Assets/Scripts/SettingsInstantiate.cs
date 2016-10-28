using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class SettingsInstantiate : MonoBehaviour {
    SettingsContainerScript container;
    FirstPersonController fpsController;
    MapGenerator mapGen;
    GameObject seekerBallSpawner;

	// Use this for initialization
	void Start () {
        container = GameObject.Find("Settings Container").GetComponent<SettingsContainerScript>();
        fpsController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
        mapGen = GameObject.Find("MapGenerator").GetComponent<MapGenerator>();
        seekerBallSpawner = GameObject.Find("Ballsy Spawner");
        
        mapGen.persistance = container.persistance;
        mapGen.noiseScale = container.noiseScale;
        mapGen.lacunarity = container.lacunarity;
        mapGen.offset = container.offset;
        mapGen.meshHeightMultiplier = container.meshHeightMultiplier;
        mapGen.seed = container.seed;
        mapGen.GenerateMap();

        fpsController.m_RunSpeed = container.runSpeed;
        seekerBallSpawner.SetActive(container.seekerBalls);


        Debug.Log(container.seed);
        Debug.Log(mapGen.seed);
        Debug.Log(container.meshHeightMultiplier);
        Debug.Log(mapGen.meshHeightMultiplier);
	}
}
