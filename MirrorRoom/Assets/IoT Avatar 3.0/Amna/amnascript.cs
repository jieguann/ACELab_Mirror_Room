using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amnascript : MonoBehaviour
{

    public Transform cube1;
    public Transform cube2;
    float virtualDist;
    float realDist;
    public Transform Realcube1;
    public Transform Realcube2;
    public GameObject env;
    bool Flag;
    // Start is called before the first frame update
    void Start()
    {
        virtualDist = cube1.position.x - cube2.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One)) {
            Realcube1.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
           
        }
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Realcube2.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            Flag = true;
        }
        if (OVRInput.GetDown(OVRInput.Button.Two) && Flag)
        {
            scaleIt();
        }
    }

    void scaleIt() {

        realDist = Realcube1.position.z - Realcube2.position.z;
        float scale = realDist / virtualDist;
        env.transform.localScale = (1 / scale) * env.transform.localScale;
        Debug.Log(911);

    }
}
