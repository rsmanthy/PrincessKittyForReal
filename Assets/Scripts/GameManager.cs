using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Planet planet;
    public List<Asteroid> asteroids;
    public List<Ship> ships;

    // Start is called before the first frame update
    void Start()
    {
        // Initalize all game start stuff
        this.planet = new Planet();
        this.asteroids = new List<Asteroid>();
        this.ships = new List<Ship>();

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
        // Call behaviors on everything? Idk   
    }
}
