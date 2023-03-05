using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UpgradeManager upgradeManager;
    public GameObject planet;
    public List<Asteroid> asteroids;
    public List<Ship> ships;

    public float t = 0;
    public GameObject asteroidPrefab;


    // Start is called before the first frame update
    void Start()
    {
        // Initalize all game start stuff
        upgradeManager = new UpgradeManager();
        asteroids = new List<Asteroid>();
        ships = new List<Ship>();

        // Check for a save file
        bool hasSaveFile = false;
        if (hasSaveFile)
        {
            // Load file
        }

        // Starts spawning asteroids
        InvokeRepeating("spawnAsteroids", 0.0f, upgradeManager.asteroidSpawnSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Call behaviors on everything? Idk   
    }

    void spawnAsteroids()
    {
        float spawnRadius = 4.0f;
        float angle = Random.Range(0, 2 * Mathf.PI);

        int health = 1;
        int oreTier = 1;

        Vector2 spawnPosition = spawnRadius * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Asteroid newAsteroid = new Asteroid(health, oreTier);
        newAsteroid.asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        asteroids.Add(newAsteroid);
    }
}
