using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour 
{
    [Range(0,500)]
    public float heightOffset = 1;
    private const int randRange = 1200;

	void Start () 
    {
        Random.seed = Random.Range(-randRange, randRange);
        int randX = Random.Range(-randRange, randRange);
        int randZ = Random.Range(-randRange, randRange);

        //Raycasting to find the y component of the x,z coordinate on the mesh, then moving gameObject to position.
        Ray ray = new Ray(new Vector3(randX,10000,randZ), Vector3.down);
        RaycastHit hit;
        bool rayHit = Physics.Raycast(ray, out hit);

        if (rayHit)
        {
            transform.position = new Vector3(randX, hit.point.y + heightOffset, randZ);
        }
	}
}
