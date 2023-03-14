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
        SceneManager.LoadScene("LobbyScene");
    }

    public void OpenManual()
    {
        manualPanel.SetActive(true);
    }

    public void CloseManual()
    {
        manualPanel.SetActive(false);
    }

    public void OpenOption()
    {
        optionPanel.SetActive(true);
    }

    public void CloseOption()
    {
        optionPanel.SetActive(false);
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
