using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public static float timer;
    private GameManager gm;
    public GameObject timeUI;

    public void Awake()
    {
        timer = 0;
        timeUI.SetActive(true);
        gm = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        int milliseconds = Mathf.FloorToInt((timer*100) % 100);
        timerText.text = string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, milliseconds);
        if(gm.GetGameWon() == true)
        {
            timeUI.SetActive(false);
        }
    }
}
