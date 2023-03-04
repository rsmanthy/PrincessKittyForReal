using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBase : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;

    // The target (cylinder) position.
    private Transform target;

    void Awake()
    {
        // Position the cube at the origin.
        transform.position = new Vector2(0.0f, 0.0f);

        // Create and position the cylinder. Reduce the size.
        var cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.localScale = new Vector2(0.15f, 1.0f);

        // Grab cylinder values and place on the target.
        target = cylinder.transform;
        target.transform.position = new Vector2(0.8f, 0.0f);

        // Position the camera.
        Camera.main.transform.position = new Vector2(0.85f, 1.0f);
        Camera.main.transform.localEulerAngles = new Vector2(15.0f, -20.0f);

    }

    void Update()
    {
        // Move our position a step closer to the target.
        var step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector2.Distance(transform.position, target.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            target.position *= -1.0f;
        }
    }
}