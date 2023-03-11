using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private int numPickups = 0;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickup"))
        {
            gameManager.PlayerPickups += 1;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Goop"))
        {
            gameManager.RestartLevel();
            Destroy(gameObject);
        }
    }
}
