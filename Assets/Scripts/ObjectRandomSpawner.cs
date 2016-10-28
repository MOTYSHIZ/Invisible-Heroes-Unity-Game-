using UnityEngine;
using System.Collections;

public class ObjectRandomSpawner : MonoBehaviour {
    [Range(0, 50)]
    public int maxObjectChunkSize = 1;

    [Range(0, 100)]
    public int numberOfChunks = 1;
    public float heightLowerBound, heightUpperBound;
    public GameObject spawnObject;

    [Range(1, 100)]
    public float chunkObjectMaxDistance;

    [Range(-10,500)]
    public float objectHeightOffset = 0;
	private const int randRange = 1200;

    //Infinite loop check variables
    float timeCheck1, timeCheck2;

	void Start () {
        float activeX, activeZ;

        Random.seed = Random.Range(-randRange, randRange);
        do {
            float randX = Random.Range(-randRange, randRange);
            float randZ = Random.Range(-randRange, randRange);
            Ray ray = new Ray(new Vector3(randX, 10000, randZ), Vector3.down);
            
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.point.y >= heightLowerBound && hit.point.y <= heightUpperBound
                    && hit.collider.gameObject.name == "Mesh")
                {
                    int tempSize = Random.Range(1, maxObjectChunkSize);
                    activeX = randX;
                    activeZ = randZ;

                    while (tempSize > 0)
                    {
                        ray = new Ray(new Vector3(activeX, 10000, activeZ), Vector3.down);
                        Physics.Raycast(ray, out hit);

                        
                        if (hit.point.y >= heightLowerBound && hit.point.y <= heightUpperBound
                            && activeX > -randRange && activeX < randRange
                            && activeZ > -randRange && activeZ < randRange
                            && hit.collider.gameObject.name == "Mesh" )
                        {
                            GameObject obj = (GameObject)Instantiate(spawnObject, new Vector3(activeX, hit.point.y + objectHeightOffset, activeZ), Quaternion.identity);
                            obj.transform.parent = gameObject.transform;
                            tempSize--;
                            timeCheck2 = Time.realtimeSinceStartup;
                        } 

                        //infinite loop check
                        if(Time.realtimeSinceStartup - timeCheck2 >= 2f){
                            tempSize--;
                        }
                        
                        activeX += Random.Range(-chunkObjectMaxDistance, chunkObjectMaxDistance);
                        activeZ += Random.Range(-chunkObjectMaxDistance, chunkObjectMaxDistance);
                    }

                    timeCheck1 = Time.realtimeSinceStartup;

                    numberOfChunks--;
                }
            }

            //Infinite loop check
            if (Time.realtimeSinceStartup - timeCheck1 >= 2f)
            {
                numberOfChunks--;
            }

        }while(numberOfChunks > 0);
	}

}
