using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseManager : MonoBehaviour
{
    public Slider baseHP;
    public WaveManager waveManager;
    public CostManager costManager;

    public void Attacked(float damage)
    {
        AudioManager.Instance.Hit();
        baseHP.value -= damage / 100f;
        GameOverCheck();
    }

    private void GameOverCheck()
    {
        if(baseHP.value > 0)
        {
            return;
        }
        else
        {
            BoxCollider2D allyBase = gameObject.GetComponent<BoxCollider2D>();
            allyBase.enabled = false;
            StartCoroutine(GameOver());
        }
    } 

    IEnumerator GameOver()
    {
        waveManager.endingObject[1].SetActive(true);
        StopCoroutine(costManager.SpawnCost());
        yield return new WaitForSeconds(4f);
        GameManager.Instance.PauseGame();
    }
}
