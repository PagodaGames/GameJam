using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour {

	private GameObject Player;
	bool attract;
	Collider col;
	Vector3 add = new Vector3(2, 2, 2);
	private float DamnTime = 5.0F;
	private Vector3 Velocity = Vector3.zero;
	private float Timer;


	// Use this for initialization
	void Start () {
		attract = false;
		Player = GameObject.Find ("[CameraRig]");
	}

	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
		if (attract) {
			//col.transform.position += 0.1F *(Player.transform.position - col.transform.position)*Time.deltaTime;
			col.transform.position = Vector3.SmoothDamp(col.transform.position, col.transform.position + (col.transform.position - Player.transform.position), ref Velocity, DamnTime);
		}
		if (Timer > 5.0) {
			attract = false;
			Destroy (this.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag != "[CameraRig]")
			attract = true;
		col = other;
	}
}
