using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour
{
    // Start is called before the first frame update
    private float dir;
    private float moment;
    private float speed = 0.001f;
    void Start()
    {
        dir = Random.Range(0, 2 * Mathf.PI);
        moment = Random.Range(-0.001f, 0.001f);
    }

    // Update is called once per frame
    void Update()
    {
        dir += moment;
        transform.position += speed * new Vector3(Mathf.Cos(dir), Mathf.Sin(dir), 0);
    }
}
