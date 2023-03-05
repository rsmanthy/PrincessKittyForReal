using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawStars : MonoBehaviour
{
    private int starCount = 1000;
    public GameObject starPrefab;
    private float angle = 0.0f;
    private float inc = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < starCount; i++)
        {
            Instantiate(starPrefab, new Vector2(Random.Range(-80f, 80f), Random.Range(-50f, 50f)), Quaternion.identity);
            angle += Random.Range(0f, 2 * Mathf.PI);
            inc += 0.001f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
