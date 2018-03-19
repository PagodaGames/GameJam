using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectCard : MonoBehaviour {

    public GameObject[] cards;
    public Texture[] display;
    public int compt;
    private int max;
    public GameObject cardDisplay;

    public GameObject controllerR;
    private testTrigger tt;

    // Use this for initialization
    void Start () {
        compt = 0;
        max = cards.Length;
        tt = controllerR.GetComponent<testTrigger>();
    }
	
	// Update is called once per frame
	void Update () {
        if (tt.swich())
        {
            compt += 1;
            if (compt == max) compt = 0;
        }

        GetComponent<shoot>().ball = cards[compt];
        cardDisplay.GetComponent<Renderer>().material.mainTexture = display[compt];
    }
}
