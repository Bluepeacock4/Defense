using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonAlly : MonoBehaviour
{
    public GameObject defenseLine;
    public GameObject[] allyObject;

    private int allyCode;

    #region Summon

    public void ActivateLine(int selectedAlly)
    {
        if (!defenseLine.activeSelf)
        {
            allyCode = selectedAlly;
            defenseLine.SetActive(true);
        }
        else
        {
            defenseLine.SetActive(false);
        }


        Button[] lineButtons = GetComponentsInChildren<Button>();
        foreach (Button button in lineButtons)
        {
            button.onClick.AddListener(() => Summon(button.transform));
        }
    }

    //public void CursorIn()
    //{
    //    Debug.Log("CursorIn");
    //}

    //public void CursorOut()
    //{
    //    Debug.Log("CursorOut");
    //    gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    //}

    public void Summon(Transform parentTransform)
    {
        Instantiate(allyObject[allyCode], parentTransform.position, Quaternion.identity);
        defenseLine.SetActive(false);
    }

    #endregion Summon
}
