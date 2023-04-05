using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public GameObject fadePanel;
    public GameObject creditCanvas;
    public float fadeSpeed = 0.5f;
    private Image fadePanelImage;

    private void Start()
    {
        fadePanelImage = fadePanel.GetComponent<Image>();
    }
    #region TitleMenu
    public void StartGame()
    {
        AudioManager.Instance.Game();
        SceneManager.LoadScene("GameScene");
    }

    public void OpenOption()
    {
        AudioManager.Instance.OpenPannel();
        AudioManager.Instance.Click();
    }

    public void FadeInMenu()
    {
        fadePanel.SetActive(true);
        StartCoroutine(DoFadeInAnimation());
        StartCoroutine(DoFadeInSound());
    }

    public void FadeOutMenu()
    {
        StartCoroutine(DoFadeOutSound());
        StartCoroutine(DoFadeOutAnimation());
    }

    private IEnumerator DoFadeInAnimation()
    {
        while(fadePanelImage.color.a < 1)
        {
            Debug.Log("ss");
            fadePanelImage.color = new Color(fadePanelImage.color.r, fadePanelImage.color.g, fadePanelImage.color.b,
                fadePanelImage.color.a + Time.deltaTime * fadeSpeed);
            yield return null;
        }
        //Å©·¡µ÷ ¶ç¿ì±â
        creditCanvas.SetActive(true);
    }
    private IEnumerator DoFadeOutAnimation()
    {
        while (fadePanelImage.color.a > 0)
        {
            fadePanelImage.color = new Color(fadePanelImage.color.r, fadePanelImage.color.g, fadePanelImage.color.b,
                fadePanelImage.color.a - Time.deltaTime * fadeSpeed);
            yield return null;
        }
    }

    private IEnumerator DoFadeInSound()
    {
        while (AudioManager.Instance.GetBgmVolume() > 0)
        {
            AudioManager.Instance.SetBgmVolume(AudioManager.Instance.GetBgmVolume() - Time.deltaTime * fadeSpeed);
            yield return null;
        }
    }

    private IEnumerator DoFadeOutSound()
    {
        yield return new WaitForSeconds(0.5f);
        AudioManager.Instance.SetBgmVolume(1f);
        AudioManager.Instance.Title();
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
