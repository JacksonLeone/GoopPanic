using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private int numPickups = 0;
    private GameManager gm;
    SpriteRenderer player;
    public Color originalColor;
    public Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<SpriteRenderer>();
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
         if (gm.PlayerPickups == 0)
        {
            player.color = originalColor;
        }
         else
        {
            player.color = newColor;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickup") && gm.PlayerPickups == 0)
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
