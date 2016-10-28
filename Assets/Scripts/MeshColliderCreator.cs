using UnityEngine;
using System.Collections;

public class MeshColliderCreator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<MeshCollider>();
	}
}
