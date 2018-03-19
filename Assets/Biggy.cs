using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biggy : MonoBehaviour {

	private bool touched;
	Collider col;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (touched) {
			
			col.transform.localScale = 1.5F * col.transform.localScale;
			touched = false;
			Destroy (this.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag != "[CameraRig]")
			touched = true;
		col = other;
	}
}
