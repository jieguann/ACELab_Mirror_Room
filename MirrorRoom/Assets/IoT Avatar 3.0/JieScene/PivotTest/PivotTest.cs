using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotTest : MonoBehaviour
{
    public Transform StartNode;
    public Transform EndNode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scale();
    }


    void Scale() {
        float distance = Vector3.Distance(StartNode.position, EndNode.position);
        this.transform.localScale = new Vector3(distance, distance, distance);

        Vector3 middlePoint = (StartNode.position + EndNode.position) / 2;
        this.transform.position = middlePoint;

        Vector3 rotationDirection = (EndNode.position - StartNode.position);
        this.transform.rotation = Quaternion.LookRotation(rotationDirection);
    }
}
