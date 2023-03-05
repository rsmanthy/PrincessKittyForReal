using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UpgradeManager upgradeManager;
    public GameObject planet;
    public List<GameObject> asteroids;
    public List<Ship> ships;

    public GameObject asteroidPrefab;
    public GameObject shipPrefab;
    private int SC = 60;


    // Start is called before the first frame update
    void Start()
    {
        // Initalize all game start stuff
        upgradeManager = new UpgradeManager();
        asteroids = new List<GameObject>();
        ships = new List<Ship>();

        // Check for a save file
        bool hasSaveFile = false;
        if (hasSaveFile)
        {
            // Load file
        }

        // Starts spawning asteroids
        InvokeRepeating("spawnAsteroids", 0.0f, upgradeManager.asteroidSpawnSpeed);
        for(int i = 0; i < SC; i++)
        {
            Instantiate(shipPrefab, new Vector2(0f, 0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Call behaviors on everything? Idk   
    }

    public float t = 0;

    void spawnAsteroids()
    {
        float spawnRadius = 12.0f + t / 10;
        t++;
        float angle = Random.Range(0, 2 * Mathf.PI);

        int health = 1;
        int oreTier = 1;

        Vector2 spawnPosition = spawnRadius * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        asteroids.Add(newAsteroid);
    }
}
