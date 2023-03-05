using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager
{
    // ##  Visual parameters ##
    // ##  Functional parameters ##
    // Speed in which asteroids spawn
    public float asteroidSpawnSpeed;

    public GameObject upgradeManager;

    // Start is called before the first frame update
    public UpgradeManager()
    {
        asteroidSpawnSpeed = 0.01f;
    }
}
