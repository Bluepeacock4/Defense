using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCredit : MonoBehaviour
{
    public float fadeSpeed = 0.5f;
    public TitleUI titleGO;
    RectTransform creditRT;
    public float scrollUpSpeed = 10f;
    private bool isCredit = false;

    private void Start()
    {
        creditRT = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(isCredit == true)
        {
            creditRT.position = new Vector3(creditRT.position.x, creditRT.position.y + (Time.deltaTime * scrollUpSpeed));

            if(creditRT.anchoredPosition.y > 1200)
            {
                isCredit = false;
                creditRT.anchoredPosition = new Vector2(0, -600);
                StartCoroutine(DoFadeOutSound());
            }
        }
    }

    private void OnEnable()
    {
        StartCoroutine(ActivateCredit());
    }

    private IEnumerator DoFadeOutSound()
    {
        while (AudioManager.Instance.GetBgmVolume() > 0)
        {
            AudioManager.Instance.SetBgmVolume(AudioManager.Instance.GetBgmVolume() - Time.deltaTime * fadeSpeed);
            yield return null;
        }

        titleGO.FadeOutMenu();
        //미친 코드입니다 ㅎㅎ 크래딧 켄버스를 지칭해요~
        gameObject.transform.parent.parent.gameObject.SetActive(false);
    }
    private IEnumerator ActivateCredit()
    {
        yield return new WaitForSeconds(3f);
        AudioManager.Instance.SetBgmVolume(1);
        AudioManager.Instance.Title(2);
        isCredit = true;
    }
}
