using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pickups;
    private GameManager gameManager;
    public int currentNumPickups;
    public int previousNumPickups = -1;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        previousNumPickups = gameManager.PlayerPickups;
    }

    void Update()
    {
        currentNumPickups = gameManager.PlayerPickups;
        if (previousNumPickups != currentNumPickups)
        {
            for (int i = 0; i < pickups.Length; i++)
            {
                if (i < currentNumPickups)
                {
                    pickups[i].SetActive(true);
                }
                else
                {
                    pickups[i].SetActive(false);
                }
            }
            previousNumPickups = currentNumPickups;
        }
    }
}
