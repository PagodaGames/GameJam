using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Video : MonoBehaviour
{
    public float timeMax;
    private float time;
    bool play = false;

    private Renderer maj;


    // Use this for initialization
    void Start()
    {

        maj = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (play)
        {
            time += Time.deltaTime;
            maj.material.color = new Color(maj.material.color.r, maj.material.color.g, maj.material.color.b, f(time));
        }

    }

    public void launch()
    {
        play = true;
        time = 0;

    }

    float f(float t)
    {
        float col = Mathf.Clamp(t * 4 * (timeMax - t), 0, 1);
        return (col);
    }
}