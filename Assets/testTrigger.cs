using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class testTrigger : MonoBehaviour {


    private Vector3 position_pre;
    private Vector3 position_rel;
    private Vector3 direction;
    bool inFire = false;
    bool lancer;

    public int controllerIndex;
    public EVRButtonId buttonIndex;
    public EVRButtonId buttonIndex2;
    // Use this for initialization
    void Awake()
    {
        position_pre = Vector3.zero;
        position_rel = Vector3.zero;
        direction = Vector3.zero;
    }


    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Controller.Input(controllerIndex).GetPressDown(buttonIndex))
        {
            if (!inFire)
            {
                position_pre = SteamVR_Controller.Input(controllerIndex).transform.pos;
                inFire = true;
            }


        }
        if (SteamVR_Controller.Input(controllerIndex).GetPressUp(buttonIndex))
        {
            if (inFire)
            {
                position_rel = SteamVR_Controller.Input(controllerIndex).transform.pos;
                direction = position_rel - position_pre;
                inFire = false;
            }
        }
    }

    public bool Fire(out Vector3 dir)
    {
        bool t = false;
        dir = direction;
        if (direction != Vector3.zero)
        {
            t = true;
            direction = Vector3.zero;
        }
        return t;
    }

    public bool swich()
    {
        bool s = false;
        if (SteamVR_Controller.Input(controllerIndex).GetPressUp(buttonIndex2))
        {
            Debug.Log("toto");
            s = true;
        }
        return s;
    }

}
