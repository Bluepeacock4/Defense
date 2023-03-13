using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    public int stageLevel;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance => _instance == null ? null : _instance;

    public void SetStageLevel(int level)
    {
        stageLevel = level;
        Debug.Log("≥≠¿Ãµµ : " + stageLevel);
    }
}
