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
        upgradePanel.SetActive(true);
    }
    public void CloseUpgrade()
    {
        upgradePanel.SetActive(false);
    }

    public void IncreaseLevel()
    {
        level = Mathf.Clamp(level + 5, 5, 100);
        levelText.text = "난이도 : " + level.ToString(); 
    }

    public void DecreaseLevel()
    {
        level = Mathf.Clamp(level - 5, 5, 100);
        levelText.text = "난이도 : " + level.ToString();
    }

    public void StartGame()
    {
        GameManager.Instance.SetStageLevel(level);
        SceneManager.LoadScene("GameScene");
    }

    public void BackTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    #endregion LobbyMenu
}
