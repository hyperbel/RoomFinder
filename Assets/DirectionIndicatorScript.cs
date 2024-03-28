using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionIndicatorScript : MonoBehaviour
{
    private Vector3 prevRotation;
    public RectTransform rect;
    private Vector3 prevPosition;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        rect = this.GetComponent<RectTransform>();
        prevRotation = new Vector3();
        prevPosition = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        RotateArrow();
        MoveArrow();
    }

    void RotateArrow()
    {
        Vector3 oldValues = this.prevRotation;
        var currentValues = RotationValues(Input.gyro.attitude);
        this.transform.Rotate(-((currentValues - oldValues)*100)); // TODO: find correct value instead of guessing 100...
        this.prevRotation = currentValues;
    }

    private static Vector3 RotationValues(Quaternion q)
    {
        return new Vector3(0, 0, q.z);
    }

    void MoveArrow()
    {
        Vector3 v = (Input.acceleration*0.5f) + this.prevPosition; // TODO: find correct value for movement instead of guessing 0.1f
        transform.position = v;
        this.prevPosition = v;
    }
}
