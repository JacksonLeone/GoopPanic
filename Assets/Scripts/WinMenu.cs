using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text rank;
    public static float timer;
    public GameObject winMenuUI;
    private GameManager gm;

    public void Awake()
    {
        timer = 0;
        winMenuUI.SetActive(false);
        gm = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        if (gm.GetGameWon() == true)
        {
            winMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        timer = Time.timeSinceLevelLoad;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        int milliseconds = Mathf.FloorToInt((timer * 100) % 100);
        timerText.text = string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, milliseconds);

        if (timer > 0)
        {
            rank.text = "A";
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Start Menu");

    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
