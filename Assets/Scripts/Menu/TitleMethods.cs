using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMethods : MonoBehaviour
{
    public List<GameObject> screens = new List<GameObject>();
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenLevelSelect()
    {
        screens[0].SetActive(false);
        screens[1].SetActive(true);
    }

    public void CloseLevelSelect()
    {
        screens[1].SetActive(false);
        screens[0].SetActive(true);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
