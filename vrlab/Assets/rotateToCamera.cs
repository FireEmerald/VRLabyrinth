using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateToCamera : MonoBehaviour { 

    public GameObject camera;
    public GameObject text;

    // Update is called once per frame
    void Update()
    {
        text.transform.rotation = Quaternion.AngleAxis(camera.transform.rotation.eulerAngles.y, Vector3.up);
    }
}
