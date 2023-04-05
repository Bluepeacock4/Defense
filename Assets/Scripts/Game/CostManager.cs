using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CostManager : MonoBehaviour
{
    public int[] unitCosts;
    public float delayTime;
    public GameObject costPrefab;
    public TextMeshProUGUI seedPointText;

    private int seedPoint;
    private float spawnInterval = 2f;
    private float yPosition = 2f;
    private float minX = -5.65f;
    private float maxX = 5.65f;


    private void Start()
    {
        StartCoroutine(SpawnCost());
    }

    public bool isEnough(int i)
    {
        return seedPoint >= unitCosts[i];
    }

    public void AddCost(int i)
    {
        seedPoint += i;
        seedPointText.text = seedPoint.ToString();
    }

    public void RemoveCost(int i)
    {
        seedPoint -= unitCosts[i];
        seedPointText.text = seedPoint.ToString();
    }

    private IEnumerator SpawnCost()
    {

        yield return new WaitForSeconds(delayTime);

        while (true)
        {
            float xPosition = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0);

            Instantiate(costPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
