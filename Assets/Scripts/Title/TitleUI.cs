using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public GameObject manualPanel;

    #region TitleMenu

    public void StartGame()
    {
        AudioManager.Instance.Game();
        SceneManager.LoadScene("GameScene");
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
        AudioManager.Instance.OpenPannel();
        AudioManager.Instance.Click();
    }

    public void CloseOption()
    {
        AudioManager.Instance.ClosePannel();
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
