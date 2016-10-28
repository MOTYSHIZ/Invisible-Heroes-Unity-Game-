using UnityEngine;
using System.Collections;

public class SettingsContainerScript : MonoBehaviour {
    [Range(1,100)]
    public float runSpeed = 50;

    public bool seekerBalls = true;

    [Range(0, 1)]
    public float persistance = 0.153f;
    public float noiseScale = 78.55f;
    public float lacunarity = 3.41f;
    public Vector2 offset = new Vector2(0,0);
    public float meshHeightMultiplier = 235.6f;
    public int seed = -1;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if(seed == -1){
            seed = Random.Range(1,100);
        }
        
	}

    public void RunSpeedChange(float speed)
    {
        runSpeed = speed;
    }

    public void SeekerBallChange(bool enabled)
    {
        seekerBalls = enabled;
    }

    public void PersistanceChange(float persistance)
    {
        this.persistance = persistance;
    }

    public void NoiseScaleChange(string noiseScale)
    {
        this.noiseScale = float.Parse(noiseScale);
    }

    public void LacunarityChange(string lacunarity)
    {
        this.lacunarity = float.Parse(lacunarity);
    }

    public void XOffsetChange(string xOffset)
    {
        offset.x = float.Parse(xOffset);
    }

    public void YOffsetChange(string yOffset)
    {
        offset.y = float.Parse(yOffset);
    }

    public void MHeightMultiplierChange(string meshHeightMultiplier)
    {
        this.meshHeightMultiplier = float.Parse(meshHeightMultiplier);
    }

    public void seedChange(string seed)
    {
        this.seed = int.Parse(seed);
    }
}
