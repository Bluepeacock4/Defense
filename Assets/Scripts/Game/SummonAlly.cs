using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonAlly : MonoBehaviour
{
    public GameObject defenseLine;
    public GameObject[] allyObject;
    public Image[] allyImage;
    public float[] coolTime;
    public CostManager unitCostManager;
    public GameObject gameGreed;

    private int allyCode;
    private Button[] lineButtons;
    private bool[] isCoolDown;

    private void Start()
    {
        isCoolDown = new bool[allyObject.Length];
    }

    public void ActivateLine(int selectedAlly)
    {
        AudioManager.Instance.Click();

        if (!defenseLine.activeSelf && !isCoolDown[selectedAlly])
        {
            allyCode = selectedAlly;

            gameGreed.SetActive(true);
            defenseLine.SetActive(true);

            SetButton(selectedAlly);
        }
        else
        {
            gameGreed.SetActive(false);
            defenseLine.SetActive(false);
        }
    }

    public IEnumerator SummonAndCoolTime(Transform parentTransform, int selectedAlly)
    {
        if (!isCoolDown[selectedAlly] && unitCostManager.isEnough(selectedAlly))
        {
            AudioManager.Instance.Click();

            //GameObject spawnedUnit = Instantiate(allyObject[allyCode], parentTransform.position, Quaternion.identity);
            //spawnedUnit.transform.SetParent(parentTransform);
            //spawnedUnit.transform.localPosition = Vector3.zero;
            //spawnedUnit.transform.SetParent(null);
            gameGreed.SetActive(false);
            defenseLine.SetActive(false);
            unitCostManager.RemoveCost(allyCode);

            isCoolDown[allyCode] = true;
            ResetButton();
            StartCoroutine(CoolTimeFillAmount(allyCode));

            yield return new WaitForSeconds(coolTime[allyCode]);
            isCoolDown[allyCode] = false;
        }
        else
        {
            allyImage[allyCode].fillAmount = 0f;
        }
    }

    IEnumerator CoolTimeFillAmount(int i)
    {
        float time = 0f;
        allyImage[i].fillAmount = 1f;

        while (time < coolTime[i])
        {
            time += Time.deltaTime;
            allyImage[i].fillAmount = 1 - (time / coolTime[i]);
            yield return null;
        }

        allyImage[i].fillAmount = 0f;

    }

    public void SetButton(int selectedAlly)
    {
        lineButtons = GetComponentsInChildren<Button>();

        foreach (Button button in lineButtons)
        {
            button.onClick.AddListener(() => StartCoroutine(SummonAndCoolTime(button.transform, selectedAlly)));
        }
    }

    public void ResetButton()
    {
        foreach (Button button in lineButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
