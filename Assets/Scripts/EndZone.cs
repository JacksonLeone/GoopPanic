using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public Color endColor;
    private GameManager gm;
    private bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (!triggered && gm.hasTreasure())
        {
            gameObject.GetComponent<SpriteRenderer>().color = endColor;
            triggered = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gm.hasTreasure() && other.CompareTag("Player"))
        {
            gm.BeatLevel();
        }
    }
}