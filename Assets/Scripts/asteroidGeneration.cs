using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // Position the cube at the origin.
        transform.position = new Vector2(0.0f, 0.0f);

        // Create and position the cylinder. Reduce the size.
        var cylinder = GameObject.CreatePrimitive(asteroidGeneration.Cylinder);
        cylinder.transform.localScale = new Vector2(0.15f, 1.0f);

        // Grab cylinder values and place on the target.
        target = cylinder.transform;
        target.transform.position = new Vector2(0.8f, 0.0f);

        // Position the camera.
        Camera.main.transform.position = new Vector2(0.85f, 1.0f);
        Camera.main.transform.localEulerAngles = new Vector2(15.0f, -20.0f);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
