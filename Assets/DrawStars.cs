using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawStars : MonoBehaviour
{
    private int starCount = 1000;
    public GameObject starPrefab;
    private float angle = 0.0f;
    private float inc = 0.02f;

    public Camera camera;
    public List<GameObject> stars;
    float lastHeight = -1;

    // Start is called before the first frame update
    void Start()
    {
        float height = camera.orthographicSize;
        lastHeight = height;
        float spawnHeight = height;
        float spawnWidth = 1.78f * height;
        for(int i = 0; i < starCount; i++)
        {
            stars.Add(Instantiate(starPrefab, new Vector2(Random.Range(-spawnWidth, spawnWidth), Random.Range(-spawnHeight, spawnHeight)), Quaternion.identity));
            angle += Random.Range(0f, 2 * Mathf.PI);
            inc += 0.001f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float height = camera.orthographicSize;
        if (lastHeight != height)
        {
            float scale = height / lastHeight;
            for(int i = 0; i < stars.Count; i++)
            {
                stars[i].transform.position = scale * stars[i].transform.position;
            }
            lastHeight = height;
        }
    }
}
