using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertKeyPointActivation : MonoBehaviour
{
    public bool inRange = false;
    public bool active = false;
    public GameObject movingBlock;
    private Vector3 startPos;
    public Transform endPos;
    public float rightLimit = 2.5f;
    public float leftLimit = 1.0f;
    public float topLimit = 1.0f;
    public float bottomLimit = 0.0f;
    public float speed = 2.0f;
    private int direction = 1;
    private Vector3 movement;
    public Vector3 vertMovement;
  
    public Transform vertStartPos;
    
    private GameManager gameManager;
    public Color activeColor;
    public Color inactiveColor;
    // Start is called before the first frame update
    void Start()
    {
        startPos = movingBlock.transform.position;
        gameManager = FindObjectOfType<GameManager>();
        print(gameObject.GetComponent<SpriteRenderer>().color);
        firstCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
         if(movingBlock.transform.position.y > topLimit)
            {
                direction = -1;
            } else if ( movingBlock.transform.position.y < bottomLimit) {
                    direction = 1;
                }
            vertMovement = Vector3.up * direction * speed * Time.deltaTime;
            movingBlock.transform.Translate(vertMovement);

        }
        if (!active)
        {
            if(movingBlock.transform.position.x > rightLimit)
            {
                direction = -1;
            } else if (movingBlock.transform.position.x < leftLimit) {
                    direction = 1;
            }
            movement = Vector3.right * direction * speed * Time.deltaTime;
            movingBlock.transform.Translate(movement);
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
        gameManager.PlayerPickups -= 1;
        gameObject.GetComponent<SpriteRenderer>().color = activeColor;
    }
    private void SetInactive()
    {
        if(gameManager.PlayerPickups == 0)
        {
     
            active = false;
            gameManager.PlayerPickups += 1;
            gameObject.GetComponent<SpriteRenderer>().color = inactiveColor;
        }
        
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
