using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelectMenu : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("Improved Start Menu");
    }

    public void PlayLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void PlayLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
}
