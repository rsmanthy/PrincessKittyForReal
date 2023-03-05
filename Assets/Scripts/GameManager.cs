using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UpgradeManager upgradeManager;
    public GameObject planet;
    public List<GameObject> asteroids;
    public List<GameObject> ships;

    public GameObject asteroidPrefab;
    public GameObject shipPrefab;
    public Camera camera;
    private float timer = 0;

    // Speed in which asteroids spawn
    public float shipSpeed;
    // Speed in which asteroids spawn
    private float asteroidSpawnSpeed = 10.0f;
    public int shipCount = 1;


    // Start is called before the first frame update
    void Start()
    {
        // Initalize all game start stuff
        upgradeManager = new UpgradeManager();
        asteroids = new List<GameObject>();
        ships = new List<GameObject>();
        timer = 0f;

        // Check for a save file
        bool hasSaveFile = false;
        if (hasSaveFile)
        {
            // Load file
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn asteroid
        timer += Time.deltaTime;
        if (timer > asteroidSpawnSpeed)
        {
            timer = 0f;
            spawnAsteroids();
        }

        while(ships.Count < shipCount)
        {
            GameObject ship = Instantiate(shipPrefab, new Vector2(0f, 0f), Quaternion.identity);
            ships.Add(ship);
        }
        // Call behaviors on everything? Idk   
    }

    public float t = 0;

    void spawnAsteroids()
    {
        float height = camera.orthographicSize;
        float spawnHeight = height;
        float spawnWidth = 1.78f * height;

        int health = 1;
        int oreTier = 1;

        Vector2 spawnPosition = new Vector2(Random.Range(-spawnWidth, spawnWidth), Random.Range(-spawnHeight, spawnHeight));
        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        asteroids.Add(newAsteroid);
    }
}
