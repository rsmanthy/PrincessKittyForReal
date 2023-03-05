using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    // ## Visual Parameters ##

    // ##  Functional parameters ## 
    public float refinementMultiplier; // Multiply money by refinement multiplier
    public int shipCount; // Max amount of ships planet can send out at any point in time

    public GameObject planet;
    public Sprite planetSprite;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = planet.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        spriteRenderer.sprite = planetSprite;

        shipCount = 0;
        refinementMultiplier = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
