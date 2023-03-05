using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchPadLand : MonoBehaviour
{
    public GameObject target;
    private bool move = true;
    private int state = 0;
    public float delay;
    private Vector2 targetLocation;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public GameObject myPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //var launchPad = GameObject.Find("LaunchPad");
        //launchPad.transform.localScale = new Vector2(1.0f, 1.0f);
        //target = launchPad;
        transform.position = new Vector2(target.transform.position.x - 0.1f,target.transform.position.y + 0.44f);
        targetLocation = new Vector2(target.transform.position.x, target.transform.position.y + 10f);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(wait(delay));
    }
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite; 
    }
    // Update is called once per frame
    void Update()
    {
        var step =  4 * Time.deltaTime; // calculate distance to move
        if(move)
        {
            newSprite = Resources.Load<Sprite>("AnimatedRocketWithFire");
            ChangeSprite();
            transform.position = Vector2.MoveTowards(transform.position, targetLocation, step);
        }
        if (Vector2.Distance(transform.position, targetLocation) < 0.001f && state == 0)
        {
            StartCoroutine(wait(5));
            state = 1;
            targetLocation = new Vector2(target.transform.position.x - 0.1f,target.transform.position.y + 0.44f);

        }
        if (Vector2.Distance(transform.position, targetLocation) < 0.001f && state == 1)
        {
            newSprite = Resources.Load<Sprite>("FirstShip");
            ChangeSprite();
            Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            StartCoroutine(wait(5));
            state = 0;
            targetLocation = new Vector2(target.transform.position.x, target.transform.position.y + 10f);
        }
    }
    IEnumerator wait(float waitTime)
    {
        move = false;
        yield return new WaitForSeconds(waitTime);
        move = true;
    }
}
