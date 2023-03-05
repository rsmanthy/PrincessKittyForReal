using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid
{
    // ##  Visual parameters ##
    // Dictates movement speed
    float speed;
    // Dictates display size
    float size;

    // ##  Functional parameters ##
    // Dictates how many times asteroid can be mined
    public int health;
    // Dictates what tier ore asteroid can give at max
    public int oreTier;

    public GameObject asteroid;

    public Sprite planetSprite;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    public Asteroid(int health, int oreTier)
    {
        this.health = health;
        this.oreTier = oreTier;
    }
}
