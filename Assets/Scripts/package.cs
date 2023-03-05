using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class package : MonoBehaviour
{ 
    private GameObject target;
    private Vector2 targetLocation;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    void Awake()
    {
        target = GameObject.Find("ConvayerBelt-Sheet_0");
        transform.position = new Vector2(target.transform.position.x + 1.9f, target.transform.position.y + 0.08f);
        targetLocation = new Vector2(-transform.position.x, transform.position.y);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite; 
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");
            /*
                Increment balance based off ship ore capacity
            */
            newSprite = Resources.Load<Sprite>("OpenCrate");
            ChangeSprite();
            Destroy(gameObject,5);
        }
        var step =  3 * Time.deltaTime; // calculate distance to move
        transform.position = Vector2.MoveTowards(transform.position, targetLocation, step);
        if (Vector2.Distance(transform.position, targetLocation) < 0.001f)
        {
            /*
                Increment balance based off ship ore capacity
            */
            Destroy(gameObject);
        }
    }
}
