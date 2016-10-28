using UnityEngine;
using System.Collections;

public class MainMenuMapGen : MonoBehaviour {
    MapGenerator mapGen;
    public bool mapScrolling = true;
    SettingsContainerScript container;

    void Start()
    {
        mapGen = GetComponent<MapGenerator>();
        container = GameObject.Find("Settings Container").GetComponent<SettingsContainerScript>();
        mapGen.seed = Random.Range(1, 1000);
    }

    // Update is called once per frame
	void Update () {
        if (mapScrolling)
        {
            container.offset.x -= .1f;
            container.offset.y -= .1f;
        }

        mapGen.offset = container.offset;
        mapGen.persistance = container.persistance;
        mapGen.noiseScale = container.noiseScale;
        mapGen.lacunarity = container.lacunarity;
        
        mapGen.meshHeightMultiplier = container.meshHeightMultiplier;
        mapGen.seed = container.seed;
        mapGen.GenerateMap();
	}

    public void MapScrollingChange(bool mapScrolling)
    {
        this.mapScrolling = mapScrolling;
    }
}
