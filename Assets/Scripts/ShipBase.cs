using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBase : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;
    private int state = 0;
    public float mineTime = 2;
    // The target (cylinder) position.
    private GameObject target;
    private bool move = true;
    private float degrees = -90; 

    void Awake()
    {
        // Position the ship at the origin.
        transform.position = new Vector2(0.0f, 0.0f);

        // Test asteroids for script
        //-----------------------------------------------
        // var asteroid = GameObject.Find("RockPlanet");
        // asteroid.transform.localScale = new Vector2(1.0f, 1.0f);
        // target = asteroid;
        // target.transform.position = new Vector2(5f, 0f);
        // asteroid = GameObject.Find("RockPlanet (" + 1 + ")");
        // asteroid.transform.localScale = new Vector2(1.0f, 1.0f);
        // target = asteroid;
        // target.transform.position = new Vector2(-5f, 0f);
        // asteroid = GameObject.Find("RockPlanet (" + 2 + ")");
        // asteroid.transform.localScale = new Vector2(1.0f, 1.0f);
        // target = asteroid;
        // target.transform.position = new Vector2(5f, 3f);
        // asteroid = GameObject.Find("RockPlanet (" + 3 + ")");
        // asteroid.transform.localScale = new Vector2(1.0f, 1.0f);
        // target = asteroid;
        // target.transform.position = new Vector2(-5f, 3f);

        // first start
        StartCoroutine(newTarget());
    }
    void Update()
    {
        if(move){
            var step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
            transform.eulerAngles = Vector3.forward * (degrees + Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg);
        }
        if(state == 0)
        {
            // Check if the position of the ship and asteroid are approximately equal.
            if (Vector2.Distance(transform.position, target.transform.position) < 0.001f)
            {
                Destroy(target, mineTime);
                StartCoroutine(mine());
                var home = GameObject.Find("Home");
                target = home;
                state = 1;
    
            }
        } else if(state == 1) {
            // Check if the position of the ship and home are approximately equal.
            if (Vector2.Distance(transform.position, target.transform.position) < 0.001f)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                state = 0;
                StartCoroutine(newTarget());
            }
        }
    }
    IEnumerator mine()
    {
        move = false;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(mineTime);
        GetComponent<SpriteRenderer>().enabled = true;
        move = true;
    }

    IEnumerator newTarget(){
        move = false;
        var rnd = Random.Range(0, 4);
        Debug.Log("ASTEROID PICKED: " + rnd);
        GameObject asteroid;
        if(rnd == 0){
            asteroid = GameObject.Find("RockPlanet");
        } else {
            asteroid = GameObject.Find("RockPlanet (" + rnd + ")");
        }
        target = asteroid;
        yield return new WaitForSeconds(0);
        GetComponent<SpriteRenderer>().enabled = true;
        move = true;
    }
}