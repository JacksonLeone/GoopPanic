using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPointActivation : MonoBehaviour
{
    public bool inRange = false;
    public bool active = false;
    public GameObject movingBlock;
    private Vector3 startPos;
    public Transform endPos;
    private GameManager gameManager;
    public Color activeColor;
    public Color inactiveColor;
    // Start is called before the first frame update
    void Start()
    {
        startPos = movingBlock.transform.position;
        gameManager = FindObjectOfType<GameManager>();
        print(gameObject.GetComponent<SpriteRenderer>().color);
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            movingBlock.transform.position = Vector2.MoveTowards(movingBlock.transform.position, endPos.position, 1.0f);
        }
        if (!active)
        {
            movingBlock.transform.position = Vector2.MoveTowards(movingBlock.transform.position, startPos, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            if (!active && gameManager.PlayerPickups > 0)
            {
                SetActive();
            }
            else if (active)
            {
                SetInactive();
            }
        }

    }
    private void SetActive()
    {
        active = true;
        //movingBlock.transform.position = endPos.position;
        gameManager.PlayerPickups -= 1;
        gameObject.GetComponent<SpriteRenderer>().color = activeColor;
    }
    private void SetInactive()
    {
        active = false;
       // movingBlock.transform.position = startPos;
        gameManager.PlayerPickups += 1;
        gameObject.GetComponent<SpriteRenderer>().color = inactiveColor;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
