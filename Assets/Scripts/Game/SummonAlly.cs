using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonAlly : MonoBehaviour
{
    [SerializeField]
    private GameObject defenseLine;
    [SerializeField]
    private GameObject[] allyObject;
    [SerializeField]
    private GameObject gameGreed;

    public CostManager unitCostManager;
    public CoolTimeManager coolTimeManager;
    public float[] coolTime;

    public int allyCode;
    public bool[] isCoolDown;
    public Image[] allyImage;

    private Button[] lineButtons;

    public void ActivateLine(int selectedAlly)
    {
        AudioManager.Instance.Click();

        if (!defenseLine.activeSelf && !isCoolDown[selectedAlly])
        {
            allyCode = selectedAlly;

            //SetButton(selectedAlly);
            gameGreed.SetActive(true);
            defenseLine.SetActive(true);

        }
        else
        {
            gameGreed.SetActive(false);
            defenseLine.SetActive(false);
        }
    }



    public void SummonUnit(Transform parentTransform)
    {
        if (!isCoolDown[allyCode] && unitCostManager.isEnough(allyCode))
        {
            AudioManager.Instance.Click();

            GameObject spawnedUnit = Instantiate(allyObject[allyCode], parentTransform.position, Quaternion.identity);
            spawnedUnit.transform.SetParent(parentTransform);
            spawnedUnit.transform.localPosition = Vector3.zero;
            spawnedUnit.transform.SetParent(null);
            gameGreed.SetActive(false);
            defenseLine.SetActive(false);
            unitCostManager.RemoveCost(allyCode);

            coolTimeManager.StartCoolDown(allyCode);
        }
    }

    //public void SetButton(int selectedAlly)
    //{
    //    lineButtons = defenseLine.GetComponentsInChildren<Button>();

    //    foreach (Button button in lineButtons)
    //    {
    //        button.onClick.AddListener(() => SummonUnit(button.transform));
    //    }
    //}

    public IEnumerator CoolTimeSu()
    {
        isCoolDown[2] = true;

        float time = 0f;
        allyImage[2].fillAmount = 1f;

        while (time < coolTime[2])
        {
            time += Time.deltaTime;
            allyImage[allyCode].fillAmount = 1 - (time / coolTime[allyCode]);
            yield return null;
        }

        allyImage[2].fillAmount = 0f;

        isCoolDown[2] = false;
    }

    public IEnumerator CoolTimeS()
    {
        isCoolDown[0] = true;

        float time = 0f;
        allyImage[0].fillAmount = 1f;

        while (time < coolTime[0])
        {
            time += Time.deltaTime;
            allyImage[0].fillAmount = 1 - (time / coolTime[0]);
            yield return null;
        }

        allyImage[0].fillAmount = 0f;

        isCoolDown[0] = false;
    }

    public IEnumerator CoolTimeB()
    {
        isCoolDown[1] = true;

        float time = 0f;
        allyImage[1].fillAmount = 1f;

        while (time < coolTime[1])
        {
            time += Time.deltaTime;
            allyImage[1].fillAmount = 1 - (time / coolTime[1]);
            yield return null;
        }

        allyImage[1].fillAmount = 0f;

        isCoolDown[1] = false;
    }
}
