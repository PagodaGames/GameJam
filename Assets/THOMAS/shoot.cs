using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public GameObject ball;
    public float speedRot;
    public float speed;
    private Camera cam;

    private Vector3 delta;

    public GameObject controllerR;

    private testTrigger tt;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        tt = controllerR.GetComponent<testTrigger>();
	}
	
	// Update is called once per frame
	void Update () {
        bool test = tt.Fire(out delta);
        Debug.Log(test);
		if(test)
        {
            Debug.Log(delta);
            ShootBall();
        }

	}

    void ShootBall()
    {
        GameObject ballToShoot = Instantiate(ball, controllerR.transform.position, Quaternion.identity);
        ballToShoot.GetComponent<Rigidbody>().angularVelocity = speedRot * delta.magnitude * Vector3.up;
        ballToShoot.GetComponent<Rigidbody>().velocity = speed * delta;
    }
}
