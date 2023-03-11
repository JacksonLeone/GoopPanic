using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PlayerPickups = 0;
    public bool beatLevel = false;
    public bool treasure = false;

    public void RestartLevel()
    {
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
        beatLevel = true;
        FindObjectOfType<GoopSpawner>().StopFlow();
        print("You beat the level!");
    }
}
