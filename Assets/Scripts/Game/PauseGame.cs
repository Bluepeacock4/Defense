using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;

    public void Pause()
    {
        GameManager.Instance.PauseGame();
        pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        GameManager.Instance.ContinueGame();
        pauseMenu.SetActive(false);
    }

    public void ReStart()
    {
        SceneManager.LoadScene("GameScene");
        GameManager.Instance.ContinueGame();
    }

    public void OpenOption()
    {
        AudioManager.Instance.OpenPannel();
    }

    public void GoTitle()
    {
        GameManager.Instance.EnterTitle();
        GameManager.Instance.ContinueGame();
        AudioManager.Instance.Title();
    }



}
