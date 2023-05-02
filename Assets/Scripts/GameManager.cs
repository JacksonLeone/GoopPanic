using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PlayerPickups = 0;
    public bool treasure = false;
    public GameObject Player;
    private bool gameWon;
    public GameObject restartUI;

    private void Start()
    {
        restartUI.SetActive(false);
    }

    public void RestartLevel()
    {
        restartUI.SetActive(true);
        print("Restart level?");
    }

    public void PickupTreasure()
    {
        treasure = true;
    }

    public bool hasTreasure()
    {
        return treasure;
    }

    public bool GetGameWon()
    {
        return gameWon;
    }
    public void BeatLevel()
    {
        gameWon = true;
        FindObjectOfType<GoopSpawner>().StopFlow();
        Player.GetComponent<TarodevController.PlayerController>().enabled = false;
        print("You beat the level!");
    }
}
