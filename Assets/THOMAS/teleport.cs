using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

    bool hasTeleport;
    bool teleporter;
    private GameObject player;
    Collider col;
    
    public Video handle;

    public AudioSource sourceSon;
    public AudioClip tolopert;

	// Use this for initialization
	void Start () {
        hasTeleport = false;
        player = GameObject.Find("[CameraRig]");
        sourceSon = player.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(teleporter && !hasTeleport)
        {
            playteleport();
        }
	}

    void playteleport()
    {
        sourceSon.clip = tolopert;
        sourceSon.Play();

        Vector3 minus = GetComponent<Rigidbody>().velocity.normalized;
        if (col.gameObject.transform.position.y <= 0.5f) minus = (transform.localPosition.y - 1) * Vector3.up;
        //panel.GetComponent<MeshRenderer>().enabled = true;

        hasTeleport = true;
        player.transform.position = transform.localPosition - 1f * minus;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        teleporter = true;
        col = other;
    }
}
