using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public GameObject manualPanel;
    public GameObject optionPanel;

    #region TitleMenu

    public void EnterLobby()
    {
        AudioManager.Instance.Click();
        SceneManager.LoadScene("LobbyScene");
    }

    public void OpenManual()
    {
        manualPanel.SetActive(true);
        AudioManager.Instance.Click();
    }

    public void CloseManual()
    {
        manualPanel.SetActive(false);
        AudioManager.Instance.Click();
    }

    public void OpenOption()
    {
        optionPanel.SetActive(true);
        AudioManager.Instance.Click();
    }

    public void CloseOption()
    {
        optionPanel.SetActive(false);
        AudioManager.Instance.Click();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    #endregion TitleMenu
}
