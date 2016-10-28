using UnityEngine;
using System.Collections;

public class ObjectiveSpawner : MonoBehaviour {
    public GameObject prefab;

    void Start()
    {
        /*cena = GameObject.Find("Cena");
        Debug.Log(cena);
        Animator animator = cena.GetComponent<Animator>();
        animator.SetTrigger("Found");
        */

    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject,0f);

        Instantiate(prefab, transform.position + new Vector3(10f,0f,0f), Quaternion.identity);
    }
}

