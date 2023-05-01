using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private int numPickups = 0;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Triggered");
        if (other.CompareTag("Pickup"))
        {
            gm.PlayerPickups += 1;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Goop"))
        {
            gm.RestartLevel();
            Destroy(gameObject);
        }
        if (gm.hasTreasure() && other.CompareTag("Exit"))
        {
            gm.BeatLevel();
        }
    }
}
