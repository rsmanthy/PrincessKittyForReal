using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class package : MonoBehaviour
{ 
    private GameObject target;
    private Vector2 targetLocation;

    void Awake()
    {
        target = GameObject.Find("ConvayerBelt-Sheet_0");
        transform.position = new Vector2(target.transform.position.x + 1.9f, target.transform.position.y + 0.08f);
        targetLocation = new Vector2(-transform.position.x, transform.position.y);
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");
            Destroy(gameObject);
        }
         
        var step =  3 * Time.deltaTime; // calculate distance to move
        transform.position = Vector2.MoveTowards(transform.position, targetLocation, step);
        if (Vector2.Distance(transform.position, targetLocation) < 0.001f)
        {
            /*
                Increment balance based off ship ore capacity
            */
            Destroy(gameObject);
        }
    }
}
