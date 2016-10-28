using UnityEngine;
using System.Collections;

public class AIBehaviour : MonoBehaviour {
    Rigidbody rig;
    public float randomForceLimit = 4, followCloseLimit = 3, followFarLimit = 10, followSpeed = 10f;
    [Range(0, 1)]
    public float changeDirectionSpeed= .2f;
    private Transform target;
    private AudioSource nyoom;

    private Transform player;
    private Transform jcPlacer;
    private Material objMat;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        jcPlacer = GameObject.Find("JC Placer").transform;
        objMat = GetComponent<Renderer>().material;
        target = player;
        rig = gameObject.GetComponent<Rigidbody>();
        nyoom = gameObject.GetComponent<AudioSource>();
	}
	
	void Update () {
        if(Input.GetKeyDown("g")){
            target = jcPlacer;
            objMat.color = Color.yellow;
        } else if(Input.GetKeyDown("f")){
            target = player;
            objMat.color = Color.white;
        }

        if (Vector3.Distance(target.position, this.transform.position) < followFarLimit)
        {
            Vector3 direction = target.position - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), changeDirectionSpeed);

            if (direction.magnitude > followCloseLimit)
            {
                rig.AddRelativeForce(0, 0, followSpeed);
            }

            if (rig.velocity.magnitude >= 5f)
            {
                nyoom.Play();
            }
        }
        else
        {
            rig.AddForce(Random.Range(-randomForceLimit, randomForceLimit), Random.Range(-randomForceLimit, randomForceLimit),
            Random.Range(-randomForceLimit, randomForceLimit), ForceMode.Force);
        }
	}
}
