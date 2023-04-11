using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureActivation : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GoopSpawner>().TriggerFlow();
            gameObject.SetActive(false);
            gameManager.PickupTreasure();
        }
    }
}
