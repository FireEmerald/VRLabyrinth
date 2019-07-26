using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Culling : MonoBehaviour { 

    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
 
        float[] distances = new float[32];
        distances[10] = 10;
        camera.layerCullDistances = distances;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
