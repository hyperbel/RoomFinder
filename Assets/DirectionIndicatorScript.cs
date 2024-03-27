using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionIndicatorScript : MonoBehaviour
{
    private Vector3 previousRotationValues = new Vector3();
    [SerializeField]
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        GyroModifyCamera();
    }
    void GyroModifyCamera()
    {
        Vector3 oldValues = this.previousRotationValues;
        var currentValues = RotationValues(Input.gyro.attitude);
        this.transform.Rotate(-((currentValues - oldValues)*100));
        this.text.text = (currentValues - oldValues).ToString();
        this.previousRotationValues = currentValues;
    }

    private static Vector3 RotationValues(Quaternion q)
    {
        return new Vector3(0, 0, q.z);
    }
}
