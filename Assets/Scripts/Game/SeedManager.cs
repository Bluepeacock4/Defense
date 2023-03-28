using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedManager : MonoBehaviour
{
    public CostManager costManager;

    void Start()
    {
        costManager = FindObjectOfType<CostManager>();
        Destroy(gameObject, 5);
    }

    private void OnMouseDown()
    {
        if (!GameManager.Instance.isPause)
        {
            costManager.AddCost(50);
            Destroy(gameObject);
        }
    }

}
