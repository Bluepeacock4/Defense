using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LobbyUI : MonoBehaviour
{
    public GameObject upgradePanel;

    public TextMeshProUGUI levelText;
    private int level = 5;

    #region LobbyMenu

    public void OpenUpgrade()
    {
        AudioManager.Instance.Click();
        upgradePanel.SetActive(true);
    }
    public void CloseUpgrade()
    {
        AudioManager.Instance.Click();
        upgradePanel.SetActive(false);
    }

    public void IncreaseLevel()
    {
        AudioManager.Instance.Click();
        level = Mathf.Clamp(level + 5, 5, 100);
        levelText.text = "난이도 : " + level.ToString(); 
    }

    public void DecreaseLevel()
    {
        AudioManager.Instance.Click();
        level = Mathf.Clamp(level - 5, 5, 100);
        levelText.text = "난이도 : " + level.ToString();
    }

    public void StartGame()
    {
        GameManager.Instance.SetStageLevel(level);
        AudioManager.Instance.Game();
        SceneManager.LoadScene("GameScene");
    }

    public void BackTitle()
    {
        AudioManager.Instance.Click();
        SceneManager.LoadScene("TitleScene");
    }

    #endregion LobbyMenu
}
