using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseManager : MonoBehaviour
{
    public Slider baseHP;

    public void Attacked(float damage)
    {
        baseHP.value -= damage / 100f;
        GameOver();
    }

    private void GameOver()
    {
        if(baseHP.value > 0)
        {
            return;
        }
        else
        {
            Debug.Log("Game Over");
        }
    } 
}
