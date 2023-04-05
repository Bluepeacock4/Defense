using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimeManager : MonoBehaviour
{

    public SummonAlly summonAlly;

    public void StartCoolDown(int allyCode)
    {   
        switch (allyCode)
        {
            case 0:
                StartSCoolDown();
                break;

            case 1:
                StartBearCoolDown();
                break;

            case 2:
                StartScunkCoolDown();
                break;
        }
    }

    public void StartSCoolDown()
    {
        if (!summonAlly.isCoolDown[0])
        {
            StartCoroutine(summonAlly.CoolTimeS());
        }
    }

    public void StartBearCoolDown()
    {
        if (!summonAlly.isCoolDown[1])
        {
            StartCoroutine(summonAlly.CoolTimeB());
        }
    }

    public void StartScunkCoolDown()
    {
        if (!summonAlly.isCoolDown[2])
        {
            StartCoroutine(summonAlly.CoolTimeSu());
        }
    }
}
