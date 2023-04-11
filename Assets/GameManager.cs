using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PlayerPickups = 0;
    public bool treasure = false;
    public GameObject Player;
    private RestartLevel rl;
    private BeatLevel bl;

    private void Start()
    {
        rl = FindObjectOfType<RestartLevel>();
        rl.gameObject.SetActive(false);
        bl = FindObjectOfType<BeatLevel>();
        bl.gameObject.SetActive(false);
    }

    public void RestartLevel()
    {
        rl.gameObject.SetActive(true);
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

    public void BeatLevel()
    {
        FindObjectOfType<GoopSpawner>().StopFlow();
        bl.gameObject.SetActive(true);
        Player.GetComponent<TarodevController.PlayerController>().enabled = false;
        print("You beat the level!");
    }
}
