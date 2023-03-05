using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBase : MonoBehaviour
{
    // Adjust the speed for the application.
    private float speed = 20.00f;
    private float mineTime = 0.4f;
    private float depositTime = 0.4f;
    // The target (cylinder) position.
    private float degrees = -90f;
    private float last = -90f;
    enum Moving { ASTEROID, PLANET, IDLE };
    private Moving state = Moving.ASTEROID;

    public GameManager gameManager;
    public GameObject planet;
    public GameObject gameManagerObject;
    public GameObject target = null;

    void Start()
    {
        speed = 2.00f;
        mineTime = 6.0f;
        depositTime = 8.0f;

        planet = GameObject.Find("Planet");
        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        selectTarget();
    }
    void Update()
    {

        speed = 1;
        mineTime = 0.4f;
        depositTime = 0.4f;
        if (target != null && state != Moving.IDLE)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
            transform.eulerAngles = Vector3.forward * (degrees + Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg);
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        if (target == null)
        {
            //Debug.Log("Selecting Target");
            selectTarget();
        }
        if (target != null && state == Moving.ASTEROID)
        {
            // Check if the position of the ship and asteroid are approximately equal.
            if (Vector2.Distance(transform.position, target.transform.position) < 0.001f)
            {
                StartCoroutine(mine());
                state = Moving.IDLE;
    
            }
        } 
        else if(target != null && state == Moving.PLANET) {
            // Check if the position of the ship and home are approximately equal.
            if (Vector2.Distance(transform.position, target.transform.position) < 0.001f)
            {
                //GetComponent<SpriteRenderer>().enabled = false;
                state = Moving.IDLE;
                StartCoroutine(depositResources());
                selectTarget();
            }
        }
    }
    IEnumerator mine()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(mineTime);
        GetComponent<SpriteRenderer>().enabled = true;
        state = Moving.PLANET;
        Destroy(target);
        target = planet;
    }

    // Selects next asteroid as target, return 0 on failure and 1 on success
    void selectTarget()
    {
        target = null;
        if (gameManager)
        {
            int asteroidListSize = gameManager.asteroids.Count;
            Debug.Log(asteroidListSize);
            if (asteroidListSize != 0)
            {
                target = gameManager.asteroids[(int)Random.Range(0, asteroidListSize)];
                //Debug.Log("Found something");
            }
        }
    }
    IEnumerator depositResources(){
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(depositTime);
        GetComponent<SpriteRenderer>().enabled = true;
        state = Moving.ASTEROID;
        selectTarget();
    }
}