using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentRoom : MonoBehaviour
    
{
    public Transform Pivot1;
    public Vector3 lookAtPosition;
    public Vector3 rightHandPosition;

    public enum AlimentState
    {
        None,
        PivotOneSet,
        PivotTwoSet
    }

    private AlimentState alimentstate;
    // Start is called before the first frame update
    void Start()
    {
        alimentstate = AlimentState.None;

    }

    // Update is called once per frame
    void Update()

    {
        


        //OVRInput.Update();
        rightHandPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        switch (alimentstate)

        {
            case AlimentState.None:
                //if (!OVRInput.GetDown(OVRInput.Button.One)) return;
                if (!Input.GetKeyDown("space")) return;
                print("button");
                Pivot1.position = rightHandPosition;
                alimentstate = AlimentState.PivotOneSet;
                 
                break;

            case AlimentState.PivotOneSet:
                if (OVRInput.GetDown(OVRInput.Button.Two))
                {
                    alimentstate = AlimentState.None;
                    return;
                }

                //if (!OVRInput.GetDown(OVRInput.Button.One)) return;
                if (!Input.GetKeyDown("space")) return;
                lookAtPosition = rightHandPosition;
                Vector3 PivotOneToTow = lookAtPosition - Pivot1.position;
                float scaleFactor = PivotOneToTow.magnitude/1.5f; /// 1.5m is the real distanfce

                Pivot1.LookAt(lookAtPosition, Vector3.up);
                Pivot1.localScale  = Pivot1.localScale * scaleFactor;
                alimentstate = AlimentState.PivotTwoSet;

                break;

            case AlimentState.PivotTwoSet:
                if (OVRInput.GetDown(OVRInput.Button.Two))
                {
                    alimentstate = AlimentState.None;
                    return;
                }

                break;

        }
    }
}
